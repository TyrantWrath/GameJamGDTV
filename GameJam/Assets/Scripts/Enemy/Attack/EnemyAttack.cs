using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private Transform player = null;
    private Animator anim = null;

    [Space(25)]
    [Header("CameraShake")]

    [Range(0f, 1f)]
    [SerializeField] float cameraShakeIntensityHitAttack = 0.5f;

    [Range(0f, 2f)]
    [SerializeField] float cameraShakeDurationHitAttack = 0.2f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
        anim = GetComponent<Animator>();
    }
    public void Attack()
    {
        CameraShake.Instance.ShakeCamera(cameraShakeDurationHitAttack, cameraShakeDurationHitAttack);
        anim.SetTrigger("Attack");
    }
}