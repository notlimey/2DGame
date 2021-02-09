using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
    public static string SteamPath;
    // Start is called before the first frame update
   private void Awake()
    {
        try
        {
            Steamworks.SteamClient.Init(1541950);
            SteamPath = Steamworks.SteamApps.AppInstallDir(1541950);
            Debug.Log(SteamPath);
        }
        catch
        {
            Debug.Log("Couldn't Initialize Steam Client");
        }

        DontDestroyOnLoad(this.gameObject);
    }

   private void OnDisable()
   {
       Steamworks.SteamClient.Shutdown();
   }

    // Update is called once per frame
    void Update()
    {
        Steamworks.SteamClient.RunCallbacks();
    }
}
