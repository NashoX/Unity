using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, Iinteractable
{
    public bool hasInteractedOnce = false;
    private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON;

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
        var dialogueSystem = FindObjectOfType<DialogueSystem>();
        
        if (!hasInteractedOnce)
        {
            hasInteractedOnce = true;
            
            if (inkJSON != null)
            {
                dialogueSystem.EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            if (inkJSON != null && !dialogueSystem.IsDialoguePlaying())
            {
                dialogueSystem.EnterDialogueMode(inkJSON);
            }
        }
    }
}