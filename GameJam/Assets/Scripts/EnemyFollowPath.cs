using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] float maxLurkTime = 0.7f;
    [SerializeField] float minLurkTime = 0.2f;

    public bool allowMovement = true;

    float waypointLurkTime;
    private int waypointIndex = 0;
    float timeSinceAtWaypoint = 0;

    bool hasCalculatedLurkTime = false;

    private void Update()
    {
        if (allowMovement)
        {
            Move();
        }
    }
    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                CalculateLurkTime();
                timeSinceAtWaypoint += Time.deltaTime;
                if (timeSinceAtWaypoint >= waypointLurkTime)
                {
                    waypointIndex++;
                    timeSinceAtWaypoint = 0;
                    hasCalculatedLurkTime = false;
                }
            }
        }
        else
        {
            waypointIndex = 0;
        }
    }

    void CalculateLurkTime()
    {
        if (hasCalculatedLurkTime) return;
        hasCalculatedLurkTime = true;
        waypointLurkTime = UnityEngine.Random.Range(minLurkTime, maxLurkTime);
    }
}
