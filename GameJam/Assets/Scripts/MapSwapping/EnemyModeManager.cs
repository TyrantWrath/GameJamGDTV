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
    public Health realEnemyHealth = null;
    public Health ghostEnemyHealth = null;

    MapSwap currentMap;

    bool hasGhostSpawned = false;
    bool isEnemyCompletelyDead = false;

    [SerializeField] int healAmount = 20;

    void Awake()
    {
        SetComponents();
    }
    private void Update()
    {
        if (currentMap != MapSwap.ghostWorld && !realEnemyHealth.isAlive) respawnTimer += Time.deltaTime;

        if (!isEnemyCompletelyDead && !realEnemyHealth.isAlive && !ghostEnemyHealth.isAlive)
        {
            isEnemyCompletelyDead = true;
            FindObjectOfType<PlayerModeManager>().GetComponent<Health>().Heal(healAmount);
            Destroy(gameObject, 1);
        }

        if (respawnTimer >= timeBeforeRespawn && !realEnemyHealth.isAlive)
        {
            EnemyRespawn();
        }
        if (!realEnemyHealth.isAlive && !hasGhostSpawned)
        {
            hasGhostSpawned = true;
            ghostEnemyInstance.transform.position = realEnemyInstance.transform.position;
            SetEnemyMode(currentMap);
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