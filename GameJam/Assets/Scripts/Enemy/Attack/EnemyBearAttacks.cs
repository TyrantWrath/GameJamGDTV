using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBearAttacks : MonoBehaviour
{
    private Animator anim = null;
    private Transform player = null;

    [Space(25)]
    [Header("CameraShake")]

    [Range(0f, 1f)]
    [SerializeField] float cameraShakeIntensityHitAttack = 0.5f;

    [Range(0f, 2f)]
    [SerializeField] float cameraShakeDurationHitAttack = 0.2f;

    [SerializeField] private float attack1Timer = 1f;
    private float currentAttack1Timer = 0f;
    private bool canAttack1 = true;

    [SerializeField] private float attack2Timer = 5f;
    private bool canAttack2 = true;
    private float currentAttack2Timer = 5f;
    private bool canRangeAttack = false;

    [SerializeField] private float rangeAttackDistance = 2f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
    }

    void Start()
    {
        currentAttack1Timer = attack1Timer;
        currentAttack2Timer = attack2Timer;
    }

    void Update()
    {
        CheckForDistance();
    }


    void FixedUpdate()
    {
        CheckTimers();

        if (canRangeAttack)
        {
            Attack2();
        }
    }

    private void CheckForDistance()
    {
        if (Vector3.Distance(player.position, transform.position) > rangeAttackDistance)
        {
            canRangeAttack = true;
        }
    }



    public void Attack()
    {
        if (canAttack1)
        {
            CameraShake.Instance.ShakeCamera(cameraShakeIntensityHitAttack, cameraShakeDurationHitAttack);
            anim.SetTrigger("Attack");
            canAttack1 = false;
        }
    }

    public void Attack2()
    {
        if (canAttack2)
        {
            SetMovementSpeedToZero();
            anim.SetTrigger("Attack2");
            canAttack2 = false;
        }
    }

    private void CheckTimers()
    {
        if (!canAttack1)
        {
            if (currentAttack1Timer > 0)
            {
                currentAttack1Timer -= Time.deltaTime;
            }
            else
            {
                currentAttack1Timer = attack1Timer;
                canAttack1 = true;
            }

        }


        if (!canAttack2)
        {
            if (currentAttack2Timer > 0)
            {
                currentAttack2Timer -= Time.deltaTime;
            }
            else
            {
                currentAttack2Timer = attack2Timer;
                canAttack2 = true;
            }

        }

    }

    private void SetMovementSpeedToZero()
    {
        GetComponentInParent<EnemyBearMovement>().speed = 0f;
    }

    private void SetMovementSpeedBack()
    {
        GetComponentInParent<EnemyBearMovement>().speed = 3f;
    }



}