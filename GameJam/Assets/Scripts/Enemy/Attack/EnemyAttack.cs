using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator anim = null;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
