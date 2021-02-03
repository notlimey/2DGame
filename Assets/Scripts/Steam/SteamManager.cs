using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
    // Start is called before the first frame update
   private void Awake()
    {
        try
        {
            Steamworks.SteamClient.Init(1541950);
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
