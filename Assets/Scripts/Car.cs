using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, Iinteractable
{
    public GameObject TpPannel;
    [SerializeField] private GameObject visualCue; // Referencia al indicador visual (opcional)


    public void Interact()
    {
      var tpsystem = FindObjectOfType<TPSystem>();
            tpsystem.ActivateTpPanel();
    }
    public GameObject GetVisualCue()
    {
        return visualCue; // Retorna el indicador visual para el personaje
    }
}

        
    

