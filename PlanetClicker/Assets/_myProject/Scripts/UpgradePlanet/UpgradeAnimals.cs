using UnityEngine;
using UnityEngine.UI;

public class UpgradeAnimals : MonoBehaviour
{
    [SerializeField] private GameObject[] animals = new GameObject[12];
    [SerializeField] private int costUpgrade, startCostUpgrade;
    [SerializeField] private int step = 0;
    [SerializeField] private float multiplie = 0;
    [SerializeField] private SaveLoadPlanetUpgrades saveLoadPlanetUpgrades;
    [SerializeField] private string stepAge, costUpgradeAge;

    //Objects on scene
    [SerializeField] private Image planet;
    [SerializeField] private GameObject buttonUpgrade;
    [SerializeField] private Image colorPanel;
    [SerializeField] private Text textCostUpgrade;
    [SerializeField] private Text money;
    [SerializeField] private GameObject nextUpgradeButton;
    [SerializeField] private ProgressBar progressBar;

    private void Start()
    {
        if (PlayerPrefs.GetInt(costUpgradeAge) == 0) { PlayerPrefs.SetInt(costUpgradeAge, startCostUpgrade); }
        costUpgrade = PlayerPrefs.GetInt(costUpgradeAge);
        step = PlayerPrefs.GetInt(stepAge);
    }

    public void UpgradeView()
    {
        money.text = (int.Parse(money.text) - costUpgrade).ToString();
        step++;

        costUpgrade = Mathf.RoundToInt(costUpgrade * multiplie);

        saveLoadPlanetUpgrades.SetNewPrefs(stepAge, costUpgradeAge, step, costUpgrade);

        UpdateView();
    }

    private void FixedUpdate()
    {
        if (int.Parse(money.text) >= costUpgrade && buttonUpgrade.activeSelf)
        {
            buttonUpgrade.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            buttonUpgrade.GetComponent<Button>().enabled = true;
            colorPanel.color = new Color32(0, 255, 0, 150);
        }
        else
        {
            buttonUpgrade.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            buttonUpgrade.GetComponent<Button>().enabled = false;
            colorPanel.color = new Color32(0, 0, 0, 150);
        }

        textCostUpgrade.text = costUpgrade.ToString();
    }

    public void UpdateView()
    {
        if (step != 50) { progressBar.UpdateBar(step % 10); } else { progressBar.UpdateBar(9); }

        if (step > 0) { animals[(step / 10) * 2].SetActive(true); animals[(step / 10) * 2 + 1].SetActive(true); } 

        if (step == 1)
        {
            buttonUpgrade.SetActive(true);
        }
        else if (step == 50)
        {
            buttonUpgrade.SetActive(false);
            nextUpgradeButton.SetActive(true);
        }
    }
}
