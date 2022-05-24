using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private Transform player = null;
    private Animator anim = null;

    [SerializeField] private float attackRange = 1f;

    [Space(25)]
    [Header("CameraShake")]

    [Range(0f, 50f)]
    [SerializeField] float cameraShakeIntensityHitAttack = 50f;

    [Range(0f, 2f)]
    [SerializeField] float cameraShakeDurationHitAttack = 0.2f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckForAttackRange();
    }
    private void CheckForAttackRange()
    {
        if (Vector3.Distance(player.position, transform.position) < attackRange)
        {
            CameraShake.Instance.ShakeCamera(cameraShakeDurationHitAttack, cameraShakeDurationHitAttack);
            anim.SetTrigger("Attack");
        }
    }
}
