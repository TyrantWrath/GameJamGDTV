using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModeManager : MonoBehaviour
{
    [SerializeField] GameObject realEnemyInstance;
    [SerializeField] GameObject ghostEnemyInstance;


    [SerializeField] float timeBeforeRespawn = 5f;
    float respawnTimer = 0;

    //Components
    Health realEnemyHealth = null;
    Health ghostEnemyHealth = null;
    HealthSpawn _healthSpawn;
    MapSwap currentMap;

    bool hasGhostSpawned = false;

    void Awake()
    {
        SetComponents();
        _healthSpawn = GetComponent<HealthSpawn>();
    }
    private void Update()
    {
        if (currentMap != MapSwap.ghostWorld && !realEnemyHealth.isAlive) respawnTimer += Time.deltaTime;

        if (!realEnemyHealth.isAlive && !hasGhostSpawned)
        {
            if (respawnTimer >= timeBeforeRespawn)
            {
                EnemyRespawn();
            }
            else
            {
                hasGhostSpawned = true;
                ghostEnemyInstance.transform.position = realEnemyInstance.transform.position;
                SetEnemyMode(currentMap);
            }
        }
        if (!ghostEnemyHealth.isAlive)
        {
            _healthSpawn.SpawnHeart(true, transform);
        }
    }
    private void SetComponents()
    {
        if (realEnemyInstance.GetComponent<Health>() != null)
        { realEnemyHealth = realEnemyInstance.GetComponent<Health>(); }

        else if (realEnemyInstance.GetComponentInChildren<Health>() != null)
        { realEnemyHealth = realEnemyInstance.GetComponentInChildren<Health>(); }

        if (realEnemyInstance.GetComponent<Health>() != null)
        { ghostEnemyHealth = ghostEnemyInstance.GetComponent<Health>(); }

        else if (realEnemyInstance.GetComponentInChildren<Health>() != null)
        { ghostEnemyHealth = ghostEnemyInstance.GetComponentInChildren<Health>(); }
    }

    public void SetEnemyMode(MapSwap map)
    {
        currentMap = map;

        if (realEnemyHealth.isAlive)
        {
            realEnemyInstance.SetActive(true);
            ghostEnemyInstance.SetActive(false);

            hasGhostSpawned = false;
        }
        else if (map == MapSwap.realWorld)
        {
            ghostEnemyInstance.SetActive(false);

        }
        else if (map == MapSwap.ghostWorld && !realEnemyHealth.isAlive && ghostEnemyHealth.isAlive)
        {
            ghostEnemyInstance.SetActive(true);

        }
    }
    public void EnemyRespawn()
    {
        if (ghostEnemyHealth.isAlive)
        {
            realEnemyHealth.ResetHealth();
            SetEnemyMode(currentMap);

            respawnTimer = 0;
        }
    }
}
