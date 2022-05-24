using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSlowDown : MonoBehaviour
{
    MonoBehaviour[] enemyMovements;
    public void UpdateWorldSpeed(MapSwap map)
    {
        if(map == MapSwap.ghostWorld)
        {
            enemyMovements = FindObjectsOfType<EnemyMovement>();

            MonoBehaviour[] enemyRangedMovements = FindObjectsOfType<EnemyRangeMovement>();
            MonoBehaviour[] enemyRangedAttacks = FindObjectsOfType<EnemyRangeAttack>();

            Animator[] animator = FindObjectsOfType<Animator>();
        }
        else if(map == MapSwap.realWorld)
        {

        }
    }

    void LoopArrays()
    {
        foreach(EnemyMovement enemyMovement in enemyMovements)
        {
            if (enemyMovement.gameObject.CompareTag(TagManager.REAL_ENEMY_TAG))
            {
                enemyMovement.speed *= 0.5f;
            }
        }
    }
}
