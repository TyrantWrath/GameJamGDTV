using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnTriggerStart : MonoBehaviour
{
    public bool isGhost = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(isGhost)
        {
            if(other.tag == "Ghost Player")
            {
                GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
        else
        {
            if(other.tag == "Player")
            {
                GetComponent<DialogueTrigger>().TriggerDialogue();
            }
            
        }
    }
}
