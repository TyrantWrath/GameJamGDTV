using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerAttack : MonoBehaviour
{
    [SerializeField] private Transform arrowSpawnPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectile2;
    public float delayBetweenAttacks;

    [SerializeField] private float skullAttackTimer = 4f;
    private float currentSkullAttackTimer = 0f;
    private bool canSkullAttack = true;

    EnemyRangeMovement rangeMovement;
    GameObject player;
    public float delayTimer;

    void Start()
    {
        rangeMovement = GetComponent<EnemyRangeMovement>();
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
    }
    void Update()
    {
        delayTimer -= Time.deltaTime;
        if(rangeMovement.isWithinRange && delayTimer <= 0 && player.activeInHierarchy)
        {
            ShootArrow();
            delayTimer = delayBetweenAttacks;
        }
    }

    void FixedUpdate()
    {
        CheckTimers();
    }

    void CheckTimers()
    {
        if(!canSkullAttack)
        {
            if(currentSkullAttackTimer > 0)
            {
                currentSkullAttackTimer -= Time.deltaTime;
            }
            else
            {
                currentSkullAttackTimer = skullAttackTimer;
                canSkullAttack = true;
            }
        }
    }


    private void ShootArrow()
    {
        if(Random.Range(0, 10) > 5)
        {
            Instantiate(projectile2, arrowSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            if(canSkullAttack)
            {
                StartCoroutine(ShootMulitpleProjectile());
                canSkullAttack = false;
            }
        }
    }

    IEnumerator ShootMulitpleProjectile()
    {
        for(int i = 0; i < 5; i++)
        {
            Instantiate(projectile, arrowSpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        
    }



}
