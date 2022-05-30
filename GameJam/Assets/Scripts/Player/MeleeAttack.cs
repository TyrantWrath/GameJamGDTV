using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] bool isPlayerReal;
    [SerializeField] int damage;
    [SerializeField] float knockback;

    [Space(25)]
    [Header("CameraShake")]

    [Range(0f, 1f)]
    [SerializeField] float cameraShakeIntensityHitAttack = 0.5f;

    [Range(0f, 2f)]
    [SerializeField] float cameraShakeDurationHitAttack = 0.2f;

    Animator _animator;
    string enemyTag;

    private void Start()
    {
        _animator = transform.parent.GetComponent<Animator>();

        if (isPlayerReal == true)
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
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(TagManager.ATTACK_ANIMATION_PARAMETER);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag(enemyTag))
        {
            if (!other.GetComponent<Health>()) return;

            CameraShake.Instance.ShakeCamera(cameraShakeIntensityHitAttack, cameraShakeDurationHitAttack);

            other.GetComponent<Health>().TakeDamage(damage);

            if (!other.GetComponent<Health>().isAlive)
            {
                return;
            }

            StartCoroutine(KnockBack(other));
        }

    }

    IEnumerator KnockBack(Collider2D enemy)
    {
        Rigidbody2D enemyRb = SetRigidBody(enemy);
        if (enemyRb == null) yield break;

        EnableScripts(enemy, false);

        enemyRb.velocity = transform.up * knockback;

        yield return new WaitForSeconds(0.25f);

        enemyRb.velocity = Vector2.zero;

        EnableScripts(enemy, true);
    }

    private static Rigidbody2D SetRigidBody(Collider2D enemy)
    {
        Rigidbody2D enemyRb = null;
        if (enemy.GetComponent<Rigidbody2D>()) enemyRb = enemy.GetComponent<Rigidbody2D>();
        else if (enemy.GetComponentInParent<Rigidbody2D>() != null) enemyRb = enemy.GetComponentInParent<Rigidbody2D>();
        return enemyRb;
    }

    private static void EnableScripts(Collider2D enemy, bool state)
    {
        if (enemy.GetComponent<EnemyRangeMovement>() != null) enemy.GetComponent<EnemyRangeMovement>().enabled = state;
        else if (enemy.GetComponent<EnemyMovement>() != null) enemy.GetComponent<EnemyMovement>().enabled = state;
        else if (enemy.GetComponentInParent<EnemyMovement>() != null) enemy.GetComponentInParent<EnemyMovement>().enabled = state;
    }
}
