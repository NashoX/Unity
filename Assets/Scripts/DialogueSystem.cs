using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueSystem : MonoBehaviour
{
    [Header("Dialogue UI")]
    public GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

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

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
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

        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            ContinueStory();
        }
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            DisplayChoices();
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
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given:" + currentChoices.Count);
        }
        int index = 0;
        
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;


        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);




    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        


    }
}