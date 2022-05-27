using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour
{

    private Transform player = null;
    private WorldSlowDown worldSlowDown = null;
    
    public float speed = 2.5f;

    public float projectileDestroyTimer = 10f;
    private Vector3 playerDirection;

    // Start is called before the first frame update
    void Awake()
    {
        
        player = GameObject.Find("Player").transform;
    }

    void Start()
    {
        WorldSlowDown worldSlowDown = FindObjectOfType<WorldSlowDown>();
        if (worldSlowDown.currentMap == MapSwap.ghostWorld && !gameObject.CompareTag(TagManager.GHOST_ENEMY_TAG))
        {
            speed /= worldSlowDown.slowFactor * 2;
        }
        Destroy(gameObject, projectileDestroyTimer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckForGhostWorld();
        Movement();
    }

    private void CheckForGhostWorld()
    {
        
       
    }

    private void Movement()
    {
        playerDirection = (player.position - transform.position).normalized;
        playerDirection.z = 0;

        transform.Translate(playerDirection * speed * Time.deltaTime);
        
    }










}
