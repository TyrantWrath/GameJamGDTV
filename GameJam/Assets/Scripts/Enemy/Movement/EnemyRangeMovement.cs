using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeMovement : MonoBehaviour
{

    private Transform player = null;
    private Vector3 playerDirection;
    private Rigidbody2D _rigidBody2D;

    private bool runAway = false;
    public bool isWithinRange = false;

    [SerializeField] public float speed = 2f;
    [SerializeField] private float rangeAttackDistance = 6f;
    [SerializeField] private float runAwayDistance = 4f;

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

    void FixedUpdate()
    {
        CheckForWithinRange();
        CheckForRunAway();

        if (!isWithinRange)
        {
            Movement();
        }

        if (runAway)
        {
            Movement();
        }
    }


    private void CheckForWithinRange()
    {
        if (Vector3.Distance(player.position, transform.position) < rangeAttackDistance)
        {
            isWithinRange = true;
        }
        else
        {
            isWithinRange = false;
        }
    }

    private void CheckForRunAway()
    {
        if (Vector3.Distance(player.position, transform.position) < runAwayDistance)
        {
            runAway = true;
        }
        else
        {
            runAway = false;
        }
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
            //transform.Translate(-playerDirection * speed * Time.deltaTime);
        }
    }
}