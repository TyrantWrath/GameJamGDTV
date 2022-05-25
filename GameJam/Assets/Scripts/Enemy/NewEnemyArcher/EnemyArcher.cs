using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
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
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    void Update()
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
            transform.Translate(-playerDirection * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(playerDirection * speed * Time.deltaTime);
        }
    }
}
