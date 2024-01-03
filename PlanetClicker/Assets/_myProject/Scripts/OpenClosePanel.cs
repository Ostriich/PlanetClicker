using UnityEngine;

public class OpenClosePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void OpenClose(bool isOpen)
    {
        panel.SetActive(isOpen);
    }
}
