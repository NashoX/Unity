using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    [SerializeField] private Transform targetPosition; // Posici�n a la que se teletransportar� el jugador
    [SerializeField] private GameObject player;        // Referencia al jugador
    [SerializeField] private GameObject tpPannel;

    // M�todo que ser� llamado cuando se presione el bot�n

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
