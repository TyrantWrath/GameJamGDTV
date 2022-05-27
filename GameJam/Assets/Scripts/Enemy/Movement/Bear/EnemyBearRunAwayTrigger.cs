using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBearRunAwayTrigger : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.CompareTag(TagManager.PLAYER_TAG))
       {
           GetComponentInParent<EnemyBearMovement>().SetTrueRunAway();
       }
   }
}
