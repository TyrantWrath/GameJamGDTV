using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArrowRotation : MonoBehaviour
{
    Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        RotateSprite();
    }
    private void RotateSprite()
    {
        Vector3 playerDirection = (player.position - transform.position).normalized;
        playerDirection.z = 0;

        float angleDirection = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDirection + 90, Vector3.forward);
    }
}
