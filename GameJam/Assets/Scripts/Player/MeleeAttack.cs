using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{ 
    private float timeBtwAttack;
    [SerializeField] float startTimeBtwAttack;

    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask whatIsEnemies;
    [SerializeField] float attackRange;
    [SerializeField] int damage;

    void Update()
    {
        SetRotation();
        if (timeBtwAttack <= 0)
        {
            // then you attack
            if (Input.GetMouseButtonDown(1))
            {
                print("Attacking");
                Collider2D[] enemeiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemeiesToDamage.Length; i++)
                {
                    enemeiesToDamage[i].GetComponent<Health>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    private void SetRotation()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10);
    }
}
