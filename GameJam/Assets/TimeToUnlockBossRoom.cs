using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToUnlockBossRoom : MonoBehaviour
{
    [SerializeField] private List<GameObject> listOfAllEnemies;

    private void Update()
    {
        for (int i = 0; i < listOfAllEnemies.Count; i++)
        {
            if (listOfAllEnemies[i] == null)
            {
                listOfAllEnemies.Remove(listOfAllEnemies[i]);
            }
            if (listOfAllEnemies.Count <= 0)
            {
                TimeToActivateBoss();
            }
        }
    }
    private void TimeToActivateBoss()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
