using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueSystem : MonoBehaviour
{
    [Header("Dialogue UI")]
    public GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Button UI")] 
    public GameObject buttonPanel;

    [Header("InkJSON")]
    private Story currentStory;
    private bool dialogueIsPlaying;

    private void Awake()
    {
        dialoguePanel.SetActive(false);
        buttonPanel.SetActive(false);
    }

    private void Start()
    {
        dialogueIsPlaying = false;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        dialoguePanel.SetActive(true);
        buttonPanel.SetActive(true);
        dialogueIsPlaying = true;

        if (currentStory == null || currentStory.state == null)
        {
            currentStory = new Story(inkJSON.text);
        }

        ContinueStory();
    }

    public void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void Update()
    {
        if (!dialogueIsPlaying) return;

        if (Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    public bool IsDialoguePlaying()
    {
        return dialogueIsPlaying;
    }
}