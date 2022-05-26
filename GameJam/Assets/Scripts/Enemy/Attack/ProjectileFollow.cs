using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour
{

    private Transform player = null;
    
    public float speed = 2.5f;

    public float projectileDestroyTimer = 10f;
    private Vector3 playerDirection;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        Debug.Log(player);
    }

    void Start()
    {
        Destroy(gameObject, projectileDestroyTimer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        playerDirection = (player.position - transform.position).normalized;
        playerDirection.z = 0;

        transform.Translate(playerDirection * speed * Time.deltaTime);
        
    }










}
