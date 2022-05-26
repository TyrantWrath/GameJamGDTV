using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour
{
    [SerializeField] GameObject heartToSpawn;
    [SerializeField] float healthAmount;

    public void SpawnHeart(bool amIDead, Transform myPosition)
    {
        if (amIDead)
        {
            Instantiate(heartToSpawn, myPosition);
        }
    }
}

