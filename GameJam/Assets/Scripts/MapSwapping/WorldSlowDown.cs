using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSlowDown : MonoBehaviour
{
    MonoBehaviour[] enemyMovements;
    MonoBehaviour[] enemyRangedMovements;
    MonoBehaviour[] enemyRangedAttacks;
    MonoBehaviour[] enemyArrows;
    Animator[] animators;

    public float slowFactor = 2;

    bool hasSlowedDown = false;
    public MapSwap currentMap;

    private void Start()
    {
        SetArrays();
    }
    public void UpdateWorldSpeed(MapSwap map)
    {
        enemyArrows = FindObjectsOfType<EnemyArrow>();
        SetArrays();
        currentMap = map;

        if (map == MapSwap.ghostWorld)
        {
            hasSlowedDown = true;
            SlowDown(true);
        }
        else if(map == MapSwap.realWorld)
        {
            if (!hasSlowedDown) return;
            SlowDown(false);
        }
    }
    void SetArrays()
    {
        enemyMovements = FindObjectsOfType<EnemyMovement>();
        enemyRangedMovements = FindObjectsOfType<EnemyRangeMovement>();
        enemyRangedAttacks = FindObjectsOfType<EnemyRangeAttack>();
        enemyArrows = FindObjectsOfType<EnemyArrow>();

        animators = FindObjectsOfType<Animator>();
    }
    void SlowDown(bool isSlow)
    {
        float multiplicationFactor;

        if(isSlow) multiplicationFactor = 1 / slowFactor;
        else multiplicationFactor = slowFactor;

        foreach(EnemyMovement enemyMovement in enemyMovements)
        {
            if (enemyMovement.gameObject.CompareTag(TagManager.REAL_ENEMY_TAG))
            {
                enemyMovement.speed *= multiplicationFactor;
            }
        }
        foreach(EnemyRangeMovement enemyRangeMovement in enemyRangedMovements)
        {
            if (enemyRangeMovement.gameObject.CompareTag(TagManager.REAL_ENEMY_TAG))
            {
                enemyRangeMovement.speed *= multiplicationFactor;
            }
        }
        foreach (EnemyArrow enemyArrow in enemyArrows)
        {
            if (enemyArrow.gameObject.CompareTag(TagManager.REAL_ENEMY_TAG))
            {
                enemyArrow.speed *= multiplicationFactor;
            }
        }

        foreach (Animator animator in animators)
        {
            if(animator.gameObject.CompareTag(TagManager.REAL_ENEMY_TAG))
            {
                animator.speed *= multiplicationFactor;
            }
        }

        foreach(EnemyRangeAttack enemyRangeAttack in enemyRangedAttacks)
        {
            if(enemyRangeAttack.gameObject.CompareTag(TagManager.REAL_ENEMY_TAG))
            {
                enemyRangeAttack.delayBetweenAttacks = enemyRangeAttack.delayBetweenAttacks / multiplicationFactor;
            }
        }
    }
}
