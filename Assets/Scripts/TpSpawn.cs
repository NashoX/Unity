using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpSpawn : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private GameObject player;        

    public void Interact()
    {
        if (targetPosition != null && player != null)
        {
            player.transform.position = targetPosition.position; 
        }
    }
    public GameObject GetVisualCue()
    {
        return visualCue; // Retorna el indicador visual para el personaje
    }
}
