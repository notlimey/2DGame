using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InputField saveName;
    public string[] saveFiles;
    public GameObject saveExists;

    [SerializeField]
    private GameObject buttonTemplate;

    public void CreateNewGame()
    {
        var complete = SerializationManager.Save(new PlayerProfile { playerName = saveName.text }, true);
        if (!complete)
        {
            saveExists.SetActive(true);
        }else
        {
            saveExists.SetActive(false);
        }
    }

    private void Start()
    {
        saveExists.SetActive(false);
        Load();
    }


    public void Load()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        saveFiles = Directory.GetDirectories(Application.persistentDataPath + "/saves/");
        foreach(var path in saveFiles)
        {
            var files = Directory.GetFiles(path);
            foreach(var file in files)
            {
                var player = SerializationManager.Load(file);
                Debug.Log(player.playerName);

                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                button.GetComponent<SavesListButton>().SetText(player.playerName);

                button.transform.SetParent(buttonTemplate.transform.parent, false);
            }
        }
    }
}

