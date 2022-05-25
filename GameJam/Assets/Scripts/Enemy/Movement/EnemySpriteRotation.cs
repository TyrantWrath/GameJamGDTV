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
        if (transform.CompareTag(TagManager.REAL_ENEMY_TAG))
        {
            player = FindObjectOfType<PlayerModeManager>().realInstance.transform;
        }
        else if (transform.CompareTag(TagManager.GHOST_ENEMY_TAG))
        {
            player = FindObjectOfType<PlayerModeManager>().ghostInstance.transform;
        }
    }

    void Update()
    {
        RotateSprite();
    }

    private void RotateSprite()
    {
        playerDirection = (player.position - transform.position).normalized;
        playerDirection.z = 0;

        angleDirection = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDirection + 90, Vector3.forward);
    }
}
