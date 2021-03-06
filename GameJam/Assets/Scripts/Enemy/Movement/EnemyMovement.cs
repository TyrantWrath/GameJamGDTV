using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyAttack enemyAttack = null;
    private Transform player = null;
    private Vector3 playerDirection;
    Rigidbody2D _rigidBody2D;

    private bool runAway = false;

    [SerializeField] float runAwayTimer = 0.5f;
    private float currentRunAwayTimer = 0f;

    [SerializeField] public float speed = 5f;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        if (transform.CompareTag(TagManager.REAL_ENEMY_TAG))
        {
            player = FindObjectOfType<PlayerModeManager>().realInstance.transform;
        }
        else if (transform.CompareTag(TagManager.GHOST_ENEMY_TAG))
        {
            player = FindObjectOfType<PlayerModeManager>().ghostInstance.transform;
        }
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

        if (runAway)
        {
            _rigidBody2D.velocity = new Vector2(-playerDirection.x, -playerDirection.y) * speed;
            //transform.Translate(-playerDirection * speed * Time.deltaTime);
        }
        else
        {
            _rigidBody2D.velocity = new Vector2(playerDirection.x, playerDirection.y) * speed;
            //transform.Translate(playerDirection * speed * Time.deltaTime);
        }
    }

    private void RunAwayTimer()
    {
        if (runAway)
        {
            if (currentRunAwayTimer > 0)
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
