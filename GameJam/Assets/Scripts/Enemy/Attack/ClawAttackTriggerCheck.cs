using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawAttackTriggerCheck : MonoBehaviour
{
    [SerializeField] int attackDamage = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            collision.GetComponentInParent<Health>().TakeDamage(attackDamage);
        }
    }
}
