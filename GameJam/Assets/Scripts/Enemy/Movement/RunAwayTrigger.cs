using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayTrigger : MonoBehaviour
{
    string playerTag;
    private void Start() {
        if(gameObject.CompareTag(TagManager.GHOST_ENEMY_TAG))
        {
            playerTag = TagManager.GHOST_PLAYER_TAG;
        }
        else playerTag = TagManager.PLAYER_TAG;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.CompareTag(playerTag))
       {
           GetComponentInParent<EnemyMovement>().SetTrueRunAway();
       }
    }
}
