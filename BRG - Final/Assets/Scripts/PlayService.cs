using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class PlayService : MonoBehaviour
{
    public static PlayGamesPlatform platform;
    public static bool isSignedGPGS;

    void Start(){
        if(!isSignedGPGS){
            ConnectGPGS();
        }
    }

    void ConnectGPGS()
    {
        if (platform == null){
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();

        }

        Social.Active.localUser.Authenticate(success => 
        {
            if (success){
                Debug.Log("Login success");
                isSignedGPGS = false;
            }
            else{
                Debug.Log("Login failed");
            }
        });

    }
}
