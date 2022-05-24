using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyAttack enemyAttack;
    private Transform player = null;
    private Vector3 playerDirection;

    private bool runAway = false;

    [SerializeField] float runAwayTimer = 0.5f;
    private float currentRunAwayTimer = 0f;

    [SerializeField] private float speed = 5f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }
    private void Start()
    {
        enemyAttack = GetComponentInChildren<EnemyAttack>();
    }
    void Update()
    {
        Movement();
    }
    void FixedUpdate()
    {
        RunAwayTimer();
    }
    private void Movement()
    {
        playerDirection = (player.position - transform.position).normalized;
        playerDirection.z = 0;

        if(runAway)
        {          
            transform.Translate(-playerDirection * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(playerDirection * speed * Time.deltaTime);
        }
    }

    private void RunAwayTimer()
    {
        if(runAway)
        {
            if(currentRunAwayTimer > 0)
            {
                currentRunAwayTimer -= Time.deltaTime;
            }
            else
            {
                runAway = false;
                currentRunAwayTimer = runAwayTimer;
            }
        }
    }

    public void SetTrueRunAway()
    {
        runAway = true;
        enemyAttack.Attack();
    }
}
