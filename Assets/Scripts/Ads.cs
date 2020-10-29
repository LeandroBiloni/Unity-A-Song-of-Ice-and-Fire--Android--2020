using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    public GameManager manager;
    public GameObject failedAd;
    public enum TypeAds
    {
        video,
        rewardedVideo
    }

    public TypeAds currentTypeAds;
    string typeAds = "";
    string gameId = "3673511";
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, true);

        typeAds = currentTypeAds.ToString();
    }

    public void PlayAd()
    {
        print("ME REPRODUZCO");
        if (Advertisement.IsReady())
            Advertisement.Show(typeAds, new ShowOptions() { resultCallback = Result });
    }

    private void Result(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            manager.HealPlayer();
            manager.adPlayed = true;
        }
        else if (result == ShowResult.Failed)
        {
            failedAd.SetActive(true);
            StartCoroutine(Lose());
        }
    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(5);
        manager.Lose();
    }
}
