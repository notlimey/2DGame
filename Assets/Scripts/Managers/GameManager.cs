using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Saving_and_Loading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InputField SaveName;
    public string[] SaveFiles;
    public GameObject _saveExists;
    public bool SaveExists = false;

    [SerializeField]
    private GameObject _buttonTemplate;

    public void CreateNewGame()
    {
        if (Directory.Exists(Application.persistentDataPath + "/saves/" + SaveName.text))
        {
            Debug.Log("Save Exists");
            SaveExists = true;
            SaveExistsImage();
            return;
        }
        SerializationManager.SavePlayer(new PlayerProfile { PlayerName = SaveName.text }, false);
    }

    public void SaveExistsImage()
    {
        if (SaveExists == true)
        {
            _saveExists.SetActive(true);
        }
    }

    public void reload()
    {
        SaveExists = false;
    }


    List<PlayerProfile> AllSaves = new List<PlayerProfile>();

    public void Load()
    {
        AllSaves.Clear();
        if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        SaveFiles = Directory.GetDirectories(Application.persistentDataPath + "/saves/");
        foreach (var path in SaveFiles)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                
                var player = SerializationManager.LoadPlayer(file);
                if (!AllSaves.Exists(p => p.PlayerName.Equals(player.PlayerName, System.StringComparison.OrdinalIgnoreCase)))
                {
                    AllSaves.Add(player);
                }
            }
        }
        foreach (var profile in AllSaves)
        {
            GameObject button = Instantiate(_buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<SavesListButton>().SetText(profile.PlayerName);


            button.transform.SetParent(_buttonTemplate.transform.parent, false);
        }
    }   
}

