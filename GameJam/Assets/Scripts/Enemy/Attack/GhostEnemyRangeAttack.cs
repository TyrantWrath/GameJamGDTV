using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemyRangeAttack : MonoBehaviour
{
    [SerializeField] Transform arrowSpawnPoint;
    [SerializeField] GameObject arrowPrefab;
    public float delayBetweenAttacks;

    EnemyRangeMovement rangeMovement;
    GameObject ghostPlayer;
    float delayTimer;
    void Awake()
    {
        rangeMovement = GetComponent<EnemyRangeMovement>();
        ghostPlayer = FindObjectOfType<PlayerModeManager>().ghostInstance;
    }
    void Update()
    {
        delayTimer -= Time.deltaTime;
        if(rangeMovement.isWithinRange && delayTimer <= 0 && ghostPlayer.activeInHierarchy)
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
