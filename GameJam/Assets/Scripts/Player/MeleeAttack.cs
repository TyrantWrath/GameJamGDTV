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

    [Range(0f, 50f)]
    [SerializeField] float cameraShakeIntensityHitAttack = 50f;

    [Range(0f, 2f)]
    [SerializeField] float cameraShakeDurationHitAttack = 1f;

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

            CameraShake.Instance.ShakeCamera(cameraShakeDurationHitAttack, cameraShakeDurationHitAttack);

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
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        EnemyRangeMovement enemyRangeMovement = enemy.GetComponent<EnemyRangeMovement>();

        if (enemyRangeMovement != null) enemyRangeMovement.enabled = false;
        if (enemyMovement != null) enemyMovement.enabled = false;

        enemy.GetComponent<Rigidbody2D>().velocity = transform.up * knockback;

        yield return new WaitForSeconds(0.25f);

        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (enemyRangeMovement != null) enemyRangeMovement.enabled = true;
        if (enemyMovement != null) enemyMovement.enabled = true;
    }
}
