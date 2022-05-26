using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawAttackTriggerCheck : MonoBehaviour
{
    [SerializeField] int attackDamage = 15;
    GameObject player;
    private void Start()
    {
        if (gameObject.CompareTag(TagManager.GHOST_ENEMY_TAG))
        {
            player = FindObjectOfType<PlayerModeManager>().ghostInstance;
        }
        else
        {
            player = FindObjectOfType<PlayerModeManager>().realInstance;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            collision.GetComponentInParent<Health>().TakeDamage(attackDamage);
        }
    }
}
