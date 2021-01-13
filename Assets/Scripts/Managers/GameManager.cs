using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections;
using Assets.Scripts.Saving_and_Loading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InputField SaveName;
    public string[] SaveFiles;
    public bool SaveExists = false;

    // SaveName Errors
    public GameObject ContainsBackSlash;
    public GameObject Slash;
    public GameObject _saveExists;

    //canvases
    public GameObject NewGame;
    public GameObject SelectOrCreate;
    public GameObject LoadGame;


    [SerializeField]
    private GameObject _buttonTemplate;

    public void CreateNewGame()
    {
        if (SaveName.text.Contains("\\"))
        {
            ContainsBackSlash.SetActive(true);
            StartCoroutine(ReloadAfterSec());
            return;

        }
        if (SaveName.text.Contains("/"))
        {
            Slash.SetActive(true);
            StartCoroutine(ReloadAfterSec());
            return;
        }

        if (Directory.Exists(Application.persistentDataPath + "/saves/" + SaveName.text))
        {
            Debug.Log("Save Exists");
            SaveExists = true;
            SaveExistsImage();
            return;
        }
        SaveSystem.SavePlayer(new PlayerProfile { PlayerName = SaveName.text }, false);
        NewGame.SetActive(false);
        LoadGame.SetActive(false);
        SelectOrCreate.SetActive(true);
       
    }

    public void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            CreateNewGame();
        }
    }

    public void SaveExistsImage()
    {
        if (SaveExists == true)
        {
            _saveExists.SetActive(true);
        }
    }

    public void Reload()
    {
        SaveExists = false;
        ContainsBackSlash.SetActive(false);
        Slash.SetActive(false);
        SaveName.text = "";
    }

    IEnumerator ReloadAfterSec()
    {
        yield return new WaitForSeconds(5);
        Reload();
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
                
                var player = SaveSystem.LoadPlayer(file);
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

