using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] bool isPlayerReal;
    [SerializeField] int damage;
    [SerializeField] float knockback;

    Animator _animator;
    string enemyTag;

    private void Start()
    {
        _animator = transform.parent.GetComponent<Animator>();

        if(isPlayerReal == true)
        {
            enemyTag = TagManager.REAL_ENEMY_TAG;
        }
        else
        {
            enemyTag = TagManager.GHOST_ENEMY_TAG;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(TagManager.ATTACK_ANIMATION_PARAMETER);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(enemyTag))
        {
            other.GetComponent<Health>().TakeDamage(damage);
            if (!other.GetComponent<Health>().isAlive) return;
            StartCoroutine(KnockBack(other));
        }
    }

    IEnumerator KnockBack(Collider2D enemy)
    {
        EnemyRangeMovement enemyRangeMovement = enemy.GetComponent<EnemyRangeMovement>();
        Rigidbody2D enemyRB = null;

        if(enemyRangeMovement != null) enemyRangeMovement.enabled = false;
        else if(enemy.GetComponent<EnemyMovement>()) enemy.GetComponent<EnemyMovement>().enabled = false;
        else if(enemy.GetComponentInParent<EnemyMovement>()) enemy.GetComponentInParent<EnemyMovement>().enabled = false;

        if (enemy.GetComponent<Rigidbody2D>()) enemyRB = enemy.GetComponent<Rigidbody2D>();
        else if (enemy.GetComponentInParent<Rigidbody2D>())
        {
            enemyRB = enemy.GetComponentInParent<Rigidbody2D>();
        }

        if (enemyRB != null) enemyRB.velocity = transform.up * knockback;

        yield return new WaitForSeconds(0.25f);

        if (enemyRB != null) enemyRB.velocity = Vector2.zero;

        if (enemyRangeMovement != null) enemyRangeMovement.enabled = true;
        else if (enemy.GetComponent<EnemyMovement>()) enemy.GetComponent<EnemyMovement>().enabled = true;
        else if (enemy.GetComponentInParent<EnemyMovement>()) enemy.GetComponentInParent<EnemyMovement>().enabled = true;
    }
}
