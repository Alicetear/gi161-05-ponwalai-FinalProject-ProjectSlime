using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    [Header("Dialogue Data")]
    public NPCDialogue dialogueData;

    [Header("UI References")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public Image portraitImage;

    private int dialogueIndex;
    private bool isTyping;
    private bool isDialogueActive;

    private float typingSpeed = 0.03f;

    public bool CanInteract()
    {
        return !isDialogueActive;
    }
    public void Interact()
    {
        if (dialoguePanel == null)
            return;

        if (PauseController.IsGamePaused)
            return;

        if (!isDialogueActive)
        {
            StartDialogue();
        }
        else
        {
            ShowNextSentence();
        }
    }


    private void StartDialogue()
    {
        dialogueIndex = 0;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);

        nameText.text = dialogueData.npcName;
        portraitImage.sprite = dialogueData.portrait;

        ShowNextSentence();
    }

    private void ShowNextSentence()
    {
        if (dialogueIndex >= dialogueData.sentences.Length)
        {
            EndDialogue();
            return;
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogueData.sentences[dialogueIndex]));
        dialogueIndex++;
    }


    private System.Collections.IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }


    public void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }
}
