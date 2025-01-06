using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, Iinteractable
{

    private GameObject visualCue;
    [SerializeField] private string example;
    [SerializeField] private DialogueSystem dialogueSystem;

    private void Awake()
    {
        visualCue = GetComponentInChildren<Transform>(true).Find("VisualCue")?.gameObject;

        if (visualCue == null)
        {
            Debug.LogWarning("VisualCue no encontrado en los hijos del NPC.");
        }
    }

    public GameObject GetVisualCue()
    {
        
        return visualCue;
    }

    public void Interact()
    {
        //Debug.Log(dialogueSystem.inkJSON);
        dialogueSystem.EnterDialogueMode(dialogueSystem.inkJSON);
    }
}
