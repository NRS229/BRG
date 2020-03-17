using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class Admob : MonoBehaviour
{
    string App_ID = "ca-app-pub-2592456455063809~1831982228";
    string Reward_AD_ID = "ca-app-pub-3940256099942544/5224354917";
    //For real string Reward_AD_ID = "ca-app-pub-2592456455063809/2126946953";

    private RewardBasedVideoAd rewardBasedVideo;

    void Start()
    {
        MobileAds.Initialize(App_ID);

        //Listen to events
        Events.requestVideoAd.AddListener(RequestRewardBasedVideo);
        Events.showVideoAd.AddListener(ShowVideoRewardAd);
    }

    public void RequestRewardBasedVideo(){
       
       rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, Reward_AD_ID);

    }

    public void ShowVideoRewardAd(){
        if (rewardBasedVideo.IsLoaded()) {
            rewardBasedVideo.Show();
        }
    }

}
