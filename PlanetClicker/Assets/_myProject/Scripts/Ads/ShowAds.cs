using UnityEngine;
using YG;

public class ShowAds : MonoBehaviour
{
    [SerializeField] private YandexGame sdk;
    [SerializeField] private GameObject warningAds;

    public void ShowRewarded(int id)
    {
        sdk._RewardedShow(id);
    }

    private void Start()
    {
        Invoke("SpawnWarning", 177);
    }

    private void SpawnWarning()
    {
        warningAds.SetActive(true);
        Invoke("ShowInstertitial", 3);
    }

    private void ShowInstertitial()
    {
        warningAds.SetActive(false);
        sdk._FullscreenShow();
        Invoke("SpawnWarning", 177);
    }
}
