using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private float timeBtwAttack;
    [SerializeField] float startTimeBtwAttack;

    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask whatIsEnemies;
    [SerializeField] float attackRange;
    [SerializeField] int damage;
    [SerializeField] float knockback;
    Animator _animator;

    private void Start()
    {
        _animator = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        SetRotation();
        if (timeBtwAttack <= 0)
        {
            // then you attack
            if (Input.GetMouseButton(1))
            {
                //_animator.SetTrigger(TagManager.ATTACK_ANIMATION_PARAMETER);

                Collider2D[] enemeiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                
                foreach(Collider2D enemy in enemeiesToDamage)
                {
                    enemy.GetComponent<Health>().TakeDamage(damage);
                    if (!enemy.GetComponent<Health>().isAlive) return;
                    StartCoroutine(KnockBack(enemy));
                    StartCoroutine(DamageEffects(enemy));
                }

                timeBtwAttack = startTimeBtwAttack;
            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }

    IEnumerator DamageEffects(Collider2D enemy)
    {
        SpriteRenderer enemySpriteRenderer = enemy.GetComponent<SpriteRenderer>();
        if(enemySpriteRenderer == null) enemySpriteRenderer = enemy.GetComponentInChildren<SpriteRenderer>();

        Color orignalColor = enemySpriteRenderer.color;
        enemySpriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.15f);

        enemySpriteRenderer.color = orignalColor;
    }

    IEnumerator KnockBack(Collider2D enemy)
    {
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        EnemyRangeMovement enemyRangeMovement = enemy.GetComponent<EnemyRangeMovement>();

        if(enemyRangeMovement != null) enemyRangeMovement.enabled = false;
        if(enemyMovement != null) enemyMovement.enabled = false;

        enemy.GetComponent<Rigidbody2D>().velocity = transform.right * knockback;

        yield return new WaitForSeconds(0.4f);

        if (enemyRangeMovement != null) enemyRangeMovement.enabled = true;
        if (enemyMovement != null) enemyMovement.enabled = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    private void SetRotation()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10);
    }
}
