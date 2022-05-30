using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnTriggerStart : MonoBehaviour
{
    public bool isGhost = false;
    public bool isEnd = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(isGhost)
        {
            if(other.tag == "Ghost Player")
            {
                if(isEnd)
                {
                    FindObjectOfType<DialogueManager>().SetIsGameOver();
                }
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
