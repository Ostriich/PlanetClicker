using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartAgain : MonoBehaviour
{
    [SerializeField] private ClickController clickController;
    [SerializeField] private Image planetView;
    [SerializeField] private Sprite startView;
    [SerializeField] private GameObject panelSure, startAgainButton;


    public void SetDefaultParameters()
    {
        PlayerPrefs.SetInt("money", 0);

        PlayerPrefs.SetInt("powerOfClick", 1);
        PlayerPrefs.SetInt("growthOfClick", 1);
        PlayerPrefs.SetInt("costClickUpgrade", 10);

        PlayerPrefs.SetInt("powerOfAutoClick", 0);
        PlayerPrefs.SetInt("growthOfAutoClick", 1);
        PlayerPrefs.SetInt("costAutoClickUpgrade", 10);

        clickController.UpdateUIInfo();

        clickController.UpdateClickInfo();
        clickController.UpdateAutoClickInfo();

        planetView.sprite = startView;

        // Upgrade Planets

        panelSure.SetActive(false);
        startAgainButton.SetActive(false);

        PlayerPrefs.SetInt("StepAge0",0);
        PlayerPrefs.SetInt("StepAge1", 0);
        PlayerPrefs.SetInt("StepAge2", 0);
        PlayerPrefs.SetInt("StepAge3", 0);
        PlayerPrefs.SetInt("StepAge4", 0);
        PlayerPrefs.SetInt("StepAge5", 0);
        PlayerPrefs.SetInt("StepAge6", 0);

        PlayerPrefs.SetInt("CostUpgradeAge0",0);
        PlayerPrefs.SetInt("CostUpgradeAge1", 0);
        PlayerPrefs.SetInt("CostUpgradeAge2", 0);
        PlayerPrefs.SetInt("CostUpgradeAge3", 0);
        PlayerPrefs.SetInt("CostUpgradeAge4", 0);
        PlayerPrefs.SetInt("CostUpgradeAge5", 0);
        PlayerPrefs.SetInt("CostUpgradeAge6", 0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
