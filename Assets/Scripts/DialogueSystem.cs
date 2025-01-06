using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Runtime.CompilerServices;


public class DialogueSystem : MonoBehaviour
{
    [Header("dialogue UI")]
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TextMeshProUGUI DialogueText;
    [Header("inkJSON")]
    public TextAsset inkJSON;
    private Story currentStory;
    private bool dialogueIsPlaying;
    private static DialogueSystem instance;
    private void Awake()
    {
        if (instance != null) {
            Debug.LogWarning("gay");
        }
        instance= this;



    }
    public static DialogueSystem GetInstance()
    {
        return instance;
    }
    private void Start()
    {
        dialogueIsPlaying = false;
        DialoguePanel.SetActive(false); 
    }
    public void EnterDialogueMode (TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        DialoguePanel.SetActive(true);
        if (currentStory.canContinue ) {
            DialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();

        }

        



    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying=false;
        DialoguePanel.SetActive(false);
        DialogueText.text = "";
    }
    private void Update()
    {
        if (!dialogueIsPlaying) {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }



        }
    private void ContinueStory()
    {
        if (currentStory.canContinue) { 
            DialogueText.text = currentStory.Continue();
        
        }
        else { ExitDialogueMode(); }


    }
    }



