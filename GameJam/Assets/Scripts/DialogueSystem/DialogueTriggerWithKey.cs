using UnityEngine;

public class DialogueTriggerWithKey : MonoBehaviour {

    public Dialogue dialogue;


    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "GhostPlayer")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }
    }


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}