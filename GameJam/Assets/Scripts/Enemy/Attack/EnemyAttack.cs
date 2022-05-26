using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator anim = null;

    [Space(25)]
    [Header("CameraShake")]

    [Range(0f, 50f)]
    [SerializeField] float cameraShakeIntensityHitAttack = 1f;

    [Range(0f, 2f)]
    [SerializeField] float cameraShakeDurationHitAttack = 0.2f;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Attack()
    {
        CameraShake.Instance.ShakeCamera(cameraShakeIntensityHitAttack, cameraShakeDurationHitAttack);
        anim.SetTrigger("Attack");
    }
}