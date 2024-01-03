using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadPlanetUpgrades : MonoBehaviour
{
    [System.Serializable] public class PlanetViews { public Sprite[] View; }

    // Planet
    [SerializeField] private Image planet;
    [SerializeField] private PlanetViews[] planetViews;
    [SerializeField] private GameObject atmos1, atmos2;
    [SerializeField] private GameObject[] animals, houses;

    // UI

    [SerializeField] private GameObject[] buttonsUpgrade;
    [SerializeField] private ProgressBar[] progressBars;
    [SerializeField] private Text[] costUpgrades;

    public void SetNewPrefs(string prefsStep, string prefsCost, int valueStep, int valueCost)
    {
        PlayerPrefs.SetInt(prefsStep, valueStep);
        PlayerPrefs.SetInt(prefsCost, valueCost);
    }

    public void UpdateInfo()
    {
        // Age 0

        if (PlayerPrefs.GetInt("StepAge0")>0)
            UpdatePlanetView(PlayerPrefs.GetInt("StepAge0"), 0);
        UpdateUIView(PlayerPrefs.GetInt("StepAge0"), 50, 0, PlayerPrefs.GetInt("CostUpgradeAge0"));

        // Age 1

        if (PlayerPrefs.GetInt("StepAge1") > 0)
            UpdatePlanetView(PlayerPrefs.GetInt("StepAge1"), 1);
        UpdateUIView(PlayerPrefs.GetInt("StepAge1"), PlayerPrefs.GetInt("StepAge0"), 1, PlayerPrefs.GetInt("CostUpgradeAge1"));

        // Age 2

        if (PlayerPrefs.GetInt("StepAge2") > 0)
            UpdateAtmos(PlayerPrefs.GetInt("StepAge2"), 2);
        UpdateUIView(PlayerPrefs.GetInt("StepAge2"), PlayerPrefs.GetInt("StepAge1"), 2, PlayerPrefs.GetInt("CostUpgradeAge2"));

        // Age 3

        if (PlayerPrefs.GetInt("StepAge3") > 0)
            UpdatePlanetView(PlayerPrefs.GetInt("StepAge3"), 2);
        UpdateUIView(PlayerPrefs.GetInt("StepAge3"), PlayerPrefs.GetInt("StepAge2"), 3, PlayerPrefs.GetInt("CostUpgradeAge3"));

        // Age 4

        if (PlayerPrefs.GetInt("StepAge4") > 0)
            UpdatePlanetView(PlayerPrefs.GetInt("StepAge4"), 3);
        UpdateUIView(PlayerPrefs.GetInt("StepAge4"), PlayerPrefs.GetInt("StepAge3"), 4, PlayerPrefs.GetInt("CostUpgradeAge4"));

        // Age 5

        if (PlayerPrefs.GetInt("StepAge5") > 0)
            UpdateAnimals(PlayerPrefs.GetInt("StepAge5"), 5);
        UpdateUIView(PlayerPrefs.GetInt("StepAge5"), PlayerPrefs.GetInt("StepAge4"), 5, PlayerPrefs.GetInt("CostUpgradeAge5"));

        // Age 6

        if (PlayerPrefs.GetInt("StepAge6") > 0)
        {
            UpdatePlanetView(PlayerPrefs.GetInt("StepAge6"), 4);
            UpdateAnimals(PlayerPrefs.GetInt("StepAge6"), 6);
            UpdateAtmos(PlayerPrefs.GetInt("StepAge6"), 6);
            UpdateHomes(PlayerPrefs.GetInt("StepAge6"));
        }
        UpdateUIView(PlayerPrefs.GetInt("StepAge6"), PlayerPrefs.GetInt("StepAge5"), 6, PlayerPrefs.GetInt("CostUpgradeAge6"));
    }

    private void Start()
    {
        UpdateInfo();
    }

    private void UpdatePlanetView(int step, int age)
    {
        planet.sprite = planetViews[age].View[step / 10];
    }

    private void UpdateUIView(int step, int previousStep, int age, int costUpgrade)
    {
        // Progress bars

        if (step != 50) { progressBars[age].UpdateBar(step % 10); } else { progressBars[age].UpdateBar(9); }

        buttonsUpgrade[age].SetActive(step<50 && previousStep == 50);

        costUpgrades[age].text = costUpgrade.ToString();
    }

    private void UpdateAtmos(int step, int age)
    {
        if (age == 2)
            switch (step)
            {
                case < 10:
                    atmos1.SetActive(true);
                    atmos1.GetComponent<Image>().color = new Color32(255, 0, 0, 50);
                    break;
                case < 20:
                    atmos1.SetActive(true);
                    atmos1.GetComponent<Image>().color = new Color32(255, 125, 125, 100);
                    break;
                case < 30:
                    atmos1.SetActive(true);
                    atmos1.GetComponent<Image>().color = new Color32(255, 255, 255, 150);
                    break;
                case < 40:
                    atmos1.SetActive(true);
                    atmos1.GetComponent<Image>().color = new Color32(150, 255, 255, 150);
                    atmos2.SetActive(true);
                    atmos2.GetComponent<Image>().color = new Color32(255, 0, 0, 25);
                    break;
                case < 50:
                    atmos1.SetActive(true);
                    atmos2.SetActive(true);
                    atmos2.GetComponent<Image>().color = new Color32(255, 125, 125, 50);
                    break;
                case 50:
                    atmos2.SetActive(true);
                    atmos1.SetActive(true);
                    atmos2.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    break;
            }
        else if (age == 6)
            switch (step)
            {
                case < 20:
                    break;
                case < 30:
                    atmos2.GetComponent<Image>().color = new Color32(255, 200, 200, 125);
                    break;
                case < 40:
                    atmos2.GetComponent<Image>().color = new Color32(255, 125, 125, 50);
                    atmos1.GetComponent<Image>().color = new Color32(255, 200, 200, 125);
                    break;
                case < 50:
                    atmos2.SetActive(false);
                    atmos1.GetComponent<Image>().color = new Color32(255, 125, 125, 100);
                    break;
                case 50:
                    atmos2.SetActive(false);
                    atmos1.GetComponent<Image>().color = new Color32(255, 0, 0, 50);
                    break;
            }

    }

    private void UpdateAnimals(int step, int age)
    {
        if (step > 0 && age == 5) 
        { 
            for (int i = 0; i <= step / 10; i++)
            {
                animals[(i) * 2].SetActive(true);
                animals[(i) * 2 + 1].SetActive(true);
            }
        }
        else if (age == 6)
        {
            for (int i = 0; i <= step / 10; i++)
            {
                animals[(i) * 2].SetActive(false);
                animals[(i) * 2 + 1].SetActive(false);
            }
        }
    }

    private void UpdateHomes(int step)
    {
        if (step > 0) { houses[step / 10].SetActive(true); }
        if (step / 10 > 0) { houses[step / 10 - 1].SetActive(false); }
    }
}
