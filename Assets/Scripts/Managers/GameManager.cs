using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InputField saveName;
    public string profileName;
    public string[] saveFiles;

    public void CreateNewGame()
    {
        profileName = saveName.text;
        SerializationManager.Save(saveName.text, profileName);
    }

    private void Start()
    {
        Load();
    }


    public void Load()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        saveFiles = Directory.GetDirectories(Application.persistentDataPath + "/saves/");
        foreach(var files in saveFiles)
        {
            Debug.Log(files);
        }
    }
}
