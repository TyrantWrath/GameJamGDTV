using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour
{

    [SerializeField] private GameObject[] gameObjectsNeeded = null;
    public bool isGhost = false;

    private void OnTriggerStay2D(Collider2D other)
    {

        if(isGhost)
        {
            if (other.tag == "Ghost Player")
            {
                for (int i = 0; i < gameObjectsNeeded.Length; i++)
                {
                    gameObjectsNeeded[i].SetActive(true);
                }
                Debug.Log("Stay");
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                for (int i = 0; i < gameObjectsNeeded.Length; i++)
                {
                    gameObjectsNeeded[i].SetActive(true);
                }
                Debug.Log("Player Stay");
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {

        if(isGhost)
        {
            if (other.tag == "Ghost Player")
            {
                for (int i = 0; i < gameObjectsNeeded.Length; i++)
                {
                    gameObjectsNeeded[i].SetActive(false);
                }
                Debug.Log("Exit");
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                for (int i = 0; i < gameObjectsNeeded.Length; i++)
                {
                    gameObjectsNeeded[i].SetActive(false);
                }
                Debug.Log("Player Exit");
            }
        }
    }







}
