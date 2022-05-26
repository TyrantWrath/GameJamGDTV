using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayTrigger : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        if(gameObject.CompareTag(TagManager.GHOST_ENEMY_TAG))
        {
            player = FindObjectOfType<PlayerModeManager>().ghostInstance;
        }
        else
        {
            player = FindObjectOfType<PlayerModeManager>().realInstance;
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
   {
       if(other.gameObject == player)
       {
           GetComponentInParent<EnemyMovement>().SetTrueRunAway();
       }
   }
}
