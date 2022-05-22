using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private Transform player = null;
    private Animator anim = null;

    [SerializeField] private float attackRange = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
