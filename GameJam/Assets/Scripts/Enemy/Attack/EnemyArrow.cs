using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{

    private Transform player = null;
    private Vector3 playerDirection;

    [SerializeField] private float speed = 8f;

   
    void Start()
    {
        player = GameObject.Find("Player").transform;
        playerDirection = (player.position - transform.position).normalized;
        playerDirection.z = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(playerDirection * speed * Time.deltaTime);
    }















}
