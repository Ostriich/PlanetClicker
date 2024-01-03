using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBar;

    public void UpdateBar(float stepUpgrade)
    {
        progressBar.fillAmount = stepUpgrade / 10f;
    }
}
