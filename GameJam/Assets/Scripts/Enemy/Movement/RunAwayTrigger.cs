using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayTrigger : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.CompareTag(TagManager.PLAYER_TAG))
       {
           GetComponentInParent<EnemyMovement>().SetTrueRunAway();
       }
   }
}
