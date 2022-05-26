using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyAttack enemyAttack;
    private Transform player = null;
    private Vector3 playerDirection;

    private bool runAway = false;

    [SerializeField] float runAwayTimer = 0.2f;
    private float currentRunAwayTimer = 0f;

    [SerializeField] public float speed = 5f;

    void Awake()
    {
        if (gameObject.CompareTag(TagManager.GHOST_ENEMY_TAG))
        {
            player = FindObjectOfType<PlayerModeManager>().ghostInstance.transform;
        }
        else
        {
            player = FindObjectOfType<PlayerModeManager>().realInstance.transform;
        }
    }
    private void Start()
    {
        enemyAttack = GetComponentInChildren<EnemyAttack>();
    }
    void FixedUpdate()
    {
        Movement();
    }
    void Update()
    {
        RunAwayTimer();
    }
    private void Movement()
    {
        playerDirection = (player.position - transform.position).normalized;
        playerDirection.z = 0;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null) rb = GetComponentInChildren<Rigidbody2D>();
        if (runAway)
        {
            //transform.Translate(-playerDirection * speed * Time.deltaTime);
            rb.velocity = new Vector2(-playerDirection.x, playerDirection.y) * speed;
        }
        else
        {
            //transform.Translate(playerDirection * speed * Time.deltaTime);
            rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * speed;
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
