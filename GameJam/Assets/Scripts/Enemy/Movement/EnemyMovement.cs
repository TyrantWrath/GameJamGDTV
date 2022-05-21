using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Transform player = null;
    //private Transform randomSpot = null;
    private Rigidbody2D rig = null;
    private Vector3 playerDirection;
    private Vector3 randomSpotDirection;

    private bool runAway = false;

    private float angleDirection;
    private float runAwayTimer = 0.2f;
    private float currentRunAwayTimer = 0f;

    [SerializeField] private float speed = 5f;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        //randomSpot = gameObject.transform.Find("RandomSpot");
        rig = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        IsTakeStepBackTimer();
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

    private void IsTakeStepBackTimer()
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
    }
































}
