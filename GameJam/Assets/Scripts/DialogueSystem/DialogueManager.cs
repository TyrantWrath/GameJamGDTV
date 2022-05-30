using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialogueText;

    Animator animator;
    PlayerModeManager playerModeManager;

    public bool isGameOver = false;

    void Start()
    {
        sentences = new Queue<string>();

        animator = GetComponent<Animator>();
        playerModeManager = FindObjectOfType<PlayerModeManager>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerModeManager.EnablePlayers(false, playerModeManager.currentMap);
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForFixedUpdate();
        }
    }
    
    private void EndDialogue()
    {
        playerModeManager.EnablePlayers(true, playerModeManager.currentMap);

        animator.SetBool("IsOpen", false);

        if(isGameOver)
        {
            SceneManager.LoadScene("CreditScene");
        }
    }

    public void SetIsGameOver()
    {
        isGameOver = true;
    }
}
