using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour, Iinteractable
{
    [SerializeField] private string sceneToLoad; // Nombre de la escena a cargar, editable desde el Inspector
    [SerializeField] private GameObject visualCue; // Referencia al indicador visual (opcional)

    public void Interact()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.Log("Cambiando a la escena: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad); // Cambiar a la escena especificada
        }
        else
        {
            Debug.LogWarning("No se ha especificado ninguna escena para cargar.");
        }
    }

    public GameObject GetVisualCue()
    {
        return visualCue; // Retorna el indicador visual para el personaje
    }
}
