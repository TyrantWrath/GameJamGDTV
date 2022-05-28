using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour
{

    [SerializeField] private GameObject[] gameObject = null;

    private void OnTriggerStay2D(Collider2D other) 
    {
        
        if(other.tag == "Ghost Player")
        {
            for(int i = 0; i < gameObject.Length; i++)
            {
                gameObject[i].SetActive(true);
            }
            Debug.Log("Stay");
        }
    }


    private void OnTriggerExit2D(Collider2D other) 
    {
        
        if(other.tag == "Ghost Player")
        {
            for(int i = 0; i < gameObject.Length; i++)
            {
                gameObject[i].SetActive(false);
            }
            Debug.Log("Exit");
        }
    }







}
