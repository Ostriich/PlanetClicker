using UnityEngine;
using UnityEngine.UI;

public class Rewarded : MonoBehaviour
{
    public bool DoubleClick, DoubleSpeed;

    public int ExtraMoneyValue;

    [SerializeField] private float timerDoubleClick, timerDoubleSpeed, timerExtraMoney;
    [SerializeField] private Text money;

    // UI

    [SerializeField] private GameObject butDoubleClick, butDoubleSpeed, butExtraMoney;
    [SerializeField] private Text txtDoubleClick, txtDoubleSpeed, txtExtraMoney;
    [SerializeField] private Image panelDoubleClick, panelDoubleSpeed, panelExtraMoney;

    [SerializeField] private GameObject simpleClickText, boostClickText, simpleAutoclickText, boostAutoclickText, extraMoneyDescription;

    private int rewardedId;

    private void FixedUpdate()
    {
        extraMoneyDescription.GetComponent<Text>().text = "+ " + ExtraMoneyValue + " очков";

        if (timerDoubleClick > 0) 
        { 
            timerDoubleClick -= Time.deltaTime;  
            txtDoubleClick.text = Mathf.Round(timerDoubleClick).ToString();
            panelDoubleClick.color = new Color32(255, 255, 0, 150);
        }
        else 
        { 
            DoubleClick = false; 
            butDoubleClick.SetActive(true); 
            simpleClickText.GetComponent<Text>().color = new Color32(255, 255, 255, 255); 
            boostClickText.SetActive(false);
            panelDoubleClick.color = new Color32(0, 255, 0, 150);
        }

        if (timerDoubleSpeed > 0) 
        { 
            timerDoubleSpeed -= Time.deltaTime; 
            txtDoubleSpeed.text = Mathf.Round(timerDoubleSpeed).ToString();
            panelDoubleSpeed.color = new Color32(255, 255, 0, 150);
        }
        else 
        { 
            DoubleSpeed = false; 
            butDoubleSpeed.SetActive(true); 
            simpleAutoclickText.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
            boostAutoclickText.SetActive(false);
            panelDoubleSpeed.color = new Color32(0, 255, 0, 150);
        }

        if (timerExtraMoney > 0) 
        { 
            timerExtraMoney -= Time.deltaTime; 
            txtExtraMoney.text = Mathf.Round(timerExtraMoney).ToString();
            panelExtraMoney.color = new Color32(255, 255, 0, 150);
        }
        else
        {
            panelExtraMoney.color = new Color32(0, 255, 0, 150);
            butExtraMoney.SetActive(true);
        }
    }

    public void RewardDoubleClick()
    {
        rewardedId = 1;
        GetComponent<ShowAds>().ShowRewarded(1);
    }

    public void RewardDoubleSpeed()
    {
        rewardedId = 2;
        GetComponent<ShowAds>().ShowRewarded(2);
    }

    public void RewardExtraMoney()
    {
        rewardedId = 3;
        GetComponent<ShowAds>().ShowRewarded(3);
    }

    public void GetReward()
    {
        switch (rewardedId)
        {
            case 1:
                GetRewardDoubleClick();
                break;
            case 2:
                GetRewardDoubleSpeed();
                break;
            case 3:
                GetRewardExtraMoney();
                break;
        }
    }


    private void GetRewardDoubleClick()
    {
        timerDoubleClick = 120;
        DoubleClick = true;
        butDoubleClick.SetActive(false);
        simpleClickText.GetComponent<Text>().color = new Color32(255, 255, 255, 1);
        boostClickText.SetActive(true);
    }

    private void GetRewardDoubleSpeed()
    {
        timerDoubleSpeed = 120;
        DoubleSpeed = true;
        butDoubleSpeed.SetActive(false);
        simpleAutoclickText.GetComponent<Text>().color = new Color32(255, 255, 255, 1);
        boostAutoclickText.SetActive(true);
    }

    private void GetRewardExtraMoney()
    {
        timerExtraMoney = 180;
        butExtraMoney.SetActive(false);
        money.text = (int.Parse(money.text) + ExtraMoneyValue).ToString();
    }
}
