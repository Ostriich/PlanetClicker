using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ClickController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text moneyText;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Rewarded rewarded;

    // Player Click
    [SerializeField] private Text costClickUpgradeText;
    [SerializeField] private GameObject buttonClickUpgrade;
    [SerializeField] private Image colorClickPanel;
    [SerializeField] private Text powerOfClickText;
    [SerializeField] private Text boostPowerOfClickText;
    [SerializeField] private Text descriptionGrowthOfClick;

    [SerializeField] private int powerOfClick = 1;
    [SerializeField] private int growthOfClick = 1;
    [SerializeField] private int costClickUpgrade = 10;

    // Autoclick

    [SerializeField] private Text costAutoClickUpgradeText;
    [SerializeField] private GameObject buttonAutoClickUpgrade;
    [SerializeField] private Image colorAutoClickPanel;
    [SerializeField] private Text powerOfAutoClickText;
    [SerializeField] private Text boostPowerOfAutoClicklickText;
    [SerializeField] private Text descriptionGrowthOfAutoClick;

    [SerializeField] private int powerOfAutoClick = 0;
    [SerializeField] private int growthOfAutoClick = 1;
    [SerializeField] private int costAutoClickUpgrade = 10;

    private void Start()
    {
        if (PlayerPrefs.GetInt("powerOfClick") == 0) PlayerPrefs.SetInt("powerOfClick", 1);
        if (PlayerPrefs.GetInt("growthOfClick") == 0) PlayerPrefs.SetInt("growthOfClick", 1);
        if (PlayerPrefs.GetInt("costClickUpgrade") == 0) PlayerPrefs.SetInt("costClickUpgrade", 10);

        if (PlayerPrefs.GetInt("growthOfAutoClick") == 0) PlayerPrefs.SetInt("growthOfAutoClick", 1);
        if (PlayerPrefs.GetInt("costAutoClickUpgrade") == 0) PlayerPrefs.SetInt("costAutoClickUpgrade", 10);

        Invoke("AutoClick", 1);

        // Click
        costClickUpgradeText.text = costClickUpgrade.ToString();
        powerOfClickText.text = powerOfClick.ToString();
        boostPowerOfClickText.text = (powerOfClick * 2).ToString();
        descriptionGrowthOfClick.text = "Сила клика +" + growthOfClick.ToString();

        // AutoClick
        costAutoClickUpgradeText.text = costClickUpgrade.ToString();
        powerOfAutoClickText.text = powerOfAutoClick.ToString() + " / сек";
        boostPowerOfAutoClicklickText.text = (powerOfAutoClick * 2).ToString() + " / сек";
        descriptionGrowthOfAutoClick.text = "Автоклик +" + growthOfAutoClick.ToString();

        moneyText.text = PlayerPrefs.GetInt("money").ToString();

        powerOfClick = PlayerPrefs.GetInt("powerOfClick");
        growthOfClick = PlayerPrefs.GetInt("growthOfClick");
        costClickUpgrade = PlayerPrefs.GetInt("costClickUpgrade");

        powerOfAutoClick = PlayerPrefs.GetInt("powerOfAutoClick");
        growthOfAutoClick = PlayerPrefs.GetInt("growthOfAutoClick");
        costAutoClickUpgrade = PlayerPrefs.GetInt("costAutoClickUpgrade");

        UpdateClickInfo();
        UpdateAutoClickInfo();
    }

    public void UpdateUIInfo()
    {

        moneyText.text = PlayerPrefs.GetInt("money").ToString();

        powerOfClick = PlayerPrefs.GetInt("powerOfClick");
        growthOfClick = PlayerPrefs.GetInt("growthOfClick");
        costClickUpgrade = PlayerPrefs.GetInt("costClickUpgrade");

        powerOfAutoClick = PlayerPrefs.GetInt("powerOfAutoClick");
        growthOfAutoClick = PlayerPrefs.GetInt("growthOfAutoClick");
        costAutoClickUpgrade = PlayerPrefs.GetInt("costAutoClickUpgrade");
    }

    public void UpgradeClick()
    {
        moneyText.text = (int.Parse(moneyText.text) - costClickUpgrade).ToString();

        // Click
        powerOfClick += growthOfClick;
        growthOfClick = Mathf.RoundToInt(powerOfClick * 0.07f) + 1;
        costClickUpgrade = Mathf.RoundToInt(costClickUpgrade * 1.15f);

        UpdateClickInfo();
    }

    public void UpdateClickInfo()
    {
        powerOfClickText.text = powerOfClick.ToString();
        boostPowerOfClickText.text = (powerOfClick * 2).ToString();
        costClickUpgradeText.text = costClickUpgrade.ToString();
        descriptionGrowthOfClick.text = "Сила клика +" + growthOfClick.ToString();
    }

    public void UpgradeAutoClick()
    {
        moneyText.text = (int.Parse(moneyText.text) - costAutoClickUpgrade).ToString();

        //AutoClick
        powerOfAutoClick += growthOfAutoClick;
        growthOfAutoClick = Mathf.RoundToInt(powerOfAutoClick * 0.07f) + 1;;
        costAutoClickUpgrade = Mathf.RoundToInt(costAutoClickUpgrade * 1.15f);

        UpdateAutoClickInfo();
    }

    public void UpdateAutoClickInfo()
    {
        powerOfAutoClickText.text = powerOfAutoClick.ToString() + " / сек";
        boostPowerOfAutoClicklickText.text = (powerOfAutoClick * 2).ToString() + " / сек";
        costAutoClickUpgradeText.text = costAutoClickUpgrade.ToString();
        descriptionGrowthOfAutoClick.text = "Автоклик +" + growthOfAutoClick.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (rewarded.DoubleClick)
        {
            moneyText.text = (int.Parse(moneyText.text) + powerOfClick * 2).ToString();
            GetComponent<ClickAnimations>().SpawnClick(powerOfClick * 2, true);
        }
        else
        {
            moneyText.text = (int.Parse(moneyText.text) + powerOfClick).ToString();
            GetComponent<ClickAnimations>().SpawnClick(powerOfClick, false);
        }
        GetComponent<ClickAnimations>().SpawnAudio(clip);
    }

    private void AutoClick()
    {
        if (powerOfAutoClick > 0)
        {
            moneyText.text = (int.Parse(moneyText.text) + powerOfAutoClick).ToString();
            GetComponent<ClickAnimations>().SpawnClick(powerOfAutoClick, false);
        }
        Invoke("AutoClick", 1 - 0.5f * Convert.ToInt32(rewarded.DoubleSpeed));
    }

    private void FixedUpdate()
    {
        rewarded.ExtraMoneyValue = powerOfClick * 150 + powerOfAutoClick * 300;

        // Click

        if (int.Parse(moneyText.text) >= costClickUpgrade && buttonClickUpgrade.activeSelf)
        {
            buttonClickUpgrade.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            buttonClickUpgrade.GetComponent<Button>().enabled = true;
            colorClickPanel.color = new Color32(0, 255, 0, 150);
        }
        else
        {
            buttonClickUpgrade.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            buttonClickUpgrade.GetComponent<Button>().enabled = false;
            colorClickPanel.color = new Color32(0, 0, 0, 150);
        }

        // AutoClick

        if (int.Parse(moneyText.text) >= costAutoClickUpgrade && buttonAutoClickUpgrade.activeSelf)
        {
            buttonAutoClickUpgrade.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            buttonAutoClickUpgrade.GetComponent<Button>().enabled = true;
            colorAutoClickPanel.color = new Color32(0, 255, 0, 150);
        }
        else
        {
            buttonAutoClickUpgrade.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            buttonAutoClickUpgrade.GetComponent<Button>().enabled = false;
            colorAutoClickPanel.color = new Color32(0, 0, 0, 150);
        }

        //Save Data

        PlayerPrefs.SetInt("money", int.Parse(moneyText.text));

        PlayerPrefs.SetInt("powerOfClick", powerOfClick);
        PlayerPrefs.SetInt("growthOfClick", growthOfClick);
        PlayerPrefs.SetInt("costClickUpgrade", costClickUpgrade);

        PlayerPrefs.SetInt("powerOfAutoClick", powerOfAutoClick);
        PlayerPrefs.SetInt("growthOfAutoClick", growthOfAutoClick);
        PlayerPrefs.SetInt("costAutoClickUpgrade", costAutoClickUpgrade);
    }
}
