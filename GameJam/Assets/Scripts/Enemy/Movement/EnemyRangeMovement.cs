using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeMovement : MonoBehaviour
{

    private Transform player = null;
    private Vector3 playerDirection;

    private bool runAway = false;
    private bool isWithinRange = false;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float rangeAttackDistance = 6f;
    [SerializeField] private float runAwayDistance = 4f;

    void Awake()
    {
        player = GameObject.Find(TagManager.PLAYER_TAG).transform;
    }


    // Update is called once per frame
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


    public void SetTrueRunAway()
    {
        runAway = true;
    }
































}
