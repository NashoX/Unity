using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Iinteractable

{
    private GameObject visualCue;
    private void Awake()
    {
        visualCue = GetComponentInChildren<Transform>(true).Find("VisualCue")?.gameObject;

        
    }
    public void Interact()

    {
        Destroy(gameObject);






    }
    public GameObject GetVisualCue()
    {

        return visualCue;
    }
}
