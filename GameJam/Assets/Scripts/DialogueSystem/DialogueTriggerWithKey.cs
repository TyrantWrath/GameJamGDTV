using UnityEngine;

public class DialogueTriggerWithKey : MonoBehaviour
{

    public Dialogue dialogue;
    public bool isGhost = false;

    private bool isWithinRange = false;
    [SerializeField] string playerTag;

    void Update()
    {
        if (isWithinRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isGhost)
        {
            if (other.tag == "Ghost Player")
            {
                isWithinRange = true;
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                isWithinRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isGhost)
        {
            if (other.tag == "Ghost Player")
            {
                isWithinRange = false;
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                isWithinRange = false;
            }
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}