using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchHandler : MonoBehaviour
{

    [SerializeField] private List<EnemyModeManager> listOfEnemiesInGroup;
    [SerializeField] private BoxCollider2D _entryBoxCollider;
    [SerializeField] private List<BoxCollider2D> _exitBoxCollider;


    /*void Start()
    {
        foreach (Transform _trans in GetComponentInChildren<Transform>())
        {
            if (_trans != this)
            {
                if (_trans.GetComponent<EnemyRangeMovement>() != null)
                {
                    listOfEnemiesInGroup.Add(_trans.GetComponent<EnemyRangeMovement>());
                }
                else if (_trans.GetComponent<EnemyMovement>() != null)
                {
                    listOfEnemiesInGroup.Add(_trans.GetComponent<EnemyRangeMovement>());
                }

            }
        }

    }*/

    public void RemoveEnemyFromGroup(EnemyModeManager enemyScripts)
    {
        listOfEnemiesInGroup.Remove(enemyScripts);
        if (listOfEnemiesInGroup.Count <= 0)
        {
            PlayerCanMoveOn(true);
        }
    }
    private void PlayerCanMoveOn(bool canPlayerMoveOn)
    {
        if (canPlayerMoveOn)
        {
            for (int i = 0; i < _exitBoxCollider.Count; i++)
            {
                _exitBoxCollider[i].isTrigger = true;
            }
        }
        if (!canPlayerMoveOn)
        {
            for (int i = 0; i < _exitBoxCollider.Count; i++)
            {
                _exitBoxCollider[i].isTrigger = false;
            }
        }
    }

}
