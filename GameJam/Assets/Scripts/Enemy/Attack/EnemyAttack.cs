using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private Transform player = null;
    private Animator anim = null;

    [SerializeField] private float attackRange = 1f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckForAttackRange();
    }
    private void CheckForAttackRange()
    {
        if(Vector3.Distance(player.position, transform.position) < attackRange)
        {
            anim.SetTrigger("Attack");
        }
    }
}
