using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [SerializeField] Transform arrowSpawnPoint;
    [SerializeField] GameObject arrowPrefab;
    public float delayBetweenAttacks;

    EnemyRangeMovement rangeMovement;
    GameObject player;
    float delayTimer;
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

    private void ShootArrow()
    {
        Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
    }
}
