using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteRotation : MonoBehaviour
{

    private Transform player = null;
    private Vector3 playerDirection;
    private float angleDirection;

    
    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotateSprite();
    }

    private void RotateSprite()
    {
        playerDirection = (player.position - transform.position).normalized;
        playerDirection.z = 0;

        angleDirection = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDirection, Vector3.forward);

    }




















}
