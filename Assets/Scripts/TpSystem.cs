using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TPSystem : MonoBehaviour
{
    public GameObject tpPanel;
    [SerializeField] private GameObject[] tpButtons;

    private void Awake()
    {
        tpPanel.SetActive(false);
    }

    public void ActivateTpPanel()
    {
        tpPanel.SetActive(true);
        StartCoroutine(SelectFirstButton());
    }

    private IEnumerator SelectFirstButton()
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(tpButtons[0]);
        Button selectedButton = tpButtons[0].GetComponent<Button>();
        if (selectedButton != null)
        {
            selectedButton.OnSelect(null);
        }

        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(tpButtons[0]);
    }

    public void CloseTeleportationPanel()
    {
        tpPanel.SetActive(false);
    }

    public void TeleportToLocation(int buttonIndex)
    {
        Debug.Log("Teleporting to location: " + buttonIndex);
        CloseTeleportationPanel();
    }
}