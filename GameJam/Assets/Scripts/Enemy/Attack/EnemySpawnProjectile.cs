using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnProjectile : MonoBehaviour
{

    [SerializeField] private GameObject projectile = null;
    [SerializeField] private Transform spawnPoint = null;

    
    public void SpawnProjectile()
    {
        Instantiate(projectile, spawnPoint.position, Quaternion.identity);
    }















}
