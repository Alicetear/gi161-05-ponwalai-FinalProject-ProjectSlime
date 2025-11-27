using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public GameObject contButton;

    public float wordSpeed = 0.05f;

    private bool playerIsClose = false;
    private int index = 0;
    public bool isTyping = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {

            if (!dialoguePanel.activeSelf)
                StartDialogue();
            else
                NextLine();
        }
    }

    private void StartDialogue()
    {
        index = 0;
        dialoguePanel.SetActive(true);
        dialogueText.text = "";
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        isTyping = false;
        contButton.SetActive(true);
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        StopAllCoroutines();
        dialoguePanel.SetActive(false);
        contButton.SetActive(false);
        dialogueText.text = "";
        index = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            EndDialogue();
        }
    }
}

