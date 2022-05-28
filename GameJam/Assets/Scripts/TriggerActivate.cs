using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour
{

    [SerializeField] private GameObject[] gameObjectsNeeded = null;

    private void OnTriggerStay2D(Collider2D other)
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


    private void OnTriggerExit2D(Collider2D other)
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







}
