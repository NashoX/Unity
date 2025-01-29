using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    [SerializeField] private Transform targetPosition; // Posición a la que se teletransportará el jugador
    [SerializeField] private GameObject player;        // Referencia al jugador
    [SerializeField] private GameObject tpPannel;

    // Método que será llamado cuando se presione el botón

    public void Teleport()
    {

        if (targetPosition != null && player != null)
        {
            tpPannel.SetActive(false);
            player.transform.position = targetPosition.position; // Teletransportar al jugador
            Destroy(gameObject);
        }
       
    }
   
}
