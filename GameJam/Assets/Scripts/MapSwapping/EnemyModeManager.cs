using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModeManager : MonoBehaviour
{
    [SerializeField] GameObject realEnemyInstance;
    [SerializeField] GameObject ghostEnemyInstance;


    [SerializeField] float timeBeforeRespawn = 5f;

    //Components
    Health realEnemyHealth = null;
    Health ghostEnemyHealth = null;
    MapSwap currentMap;

    bool hasGhostSpawned = false;

    void Start()
    {
        SetComponents();
    }
    private void Update()
    {
        if (!realEnemyHealth.isAlive && !hasGhostSpawned)
        {
            ghostEnemyInstance.transform.position = realEnemyInstance.transform.position;
            StartCoroutine(EnemyRespawnTimer());
            hasGhostSpawned = true;
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
    public IEnumerator EnemyRespawnTimer()
    {
        yield return new WaitForSeconds(timeBeforeRespawn);
        if (ghostEnemyHealth.isAlive)
        {
            realEnemyHealth.ResetHealth();
            SetEnemyMode(currentMap);
        }
    }
}
