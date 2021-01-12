using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saving_and_Loading;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static string Username;

    void Start()
    {
        StartCoroutine(AutoSave());
        LoadPlayer();
    }


    IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            SerializationManager.SavePlayer(this, false);
            Debug.Log("Auto-saving...");
        }
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/saves/" + Username + "/" + Username + ".dat";
        PlayerProfile data = SerializationManager.LoadPlayer(path);

        Vector3 position;
        position.x = data.Position[0];
        position.y = data.Position[1];
        position.z = data.Position[2];

        transform.position = position;
        
    }
}
