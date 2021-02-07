using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections;
using Assets.Scripts.Saving_and_Loading;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Objects
    // Main GameObject which controls animations
    public GameObject MainCanvas;

    // GameObjects for panels
    public GameObject mainMenu;
    public GameObject optionsPanel;
    public GameObject newGamePanel;
    public GameObject loadGamePanel;
    public GameObject Slider;

    
    public InputField SaveName;

    // SaveFiles that exists
    private string[] SaveFiles;

    // This updates if save exists
    private bool SaveExists = false;

    // SaveName Errors
    public GameObject ContainsBackSlash;
    public GameObject Slash;
    public GameObject _saveExists;

    // Parent of buttontemplate
    public Transform buttonParent;

    // Button template for the load game 
    [SerializeField]
    private GameObject _buttonTemplate;

    #endregion

    private IEnumerator WaitForMainMenu(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Slider.SetActive(false);
        mainMenu.SetActive(true);
    }

    void Start()
    {
        mainMenu.SetActive(true);
        optionsPanel.SetActive(false);
        newGamePanel.SetActive(false);
        loadGamePanel.SetActive(false);
        Slider.SetActive(false);
    }

    #region Canvases
    public void NewGame()
    {
        newGamePanel.SetActive(true);
        mainMenu.SetActive(false);

        Slider.SetActive(true);
        MainCanvas.GetComponent<Animation>().Play("SlideIntoPanel");
    }

    public void LoadGame()
    {
        loadGamePanel.SetActive(true);
        mainMenu.SetActive(false);

        Slider.SetActive(true);
        MainCanvas.GetComponent<Animation>().Play("SlideIntoPanel");
        Load();
    }

    public void Settings()
    {
        optionsPanel.SetActive(true);
        mainMenu.SetActive(false);
        
        Slider.SetActive(true);
        MainCanvas.GetComponent<Animation>().Play("SlideIntoPanel");
    }

    public void BackToMain()
    {
        optionsPanel.SetActive(false);
        loadGamePanel.SetActive(false);
        newGamePanel.SetActive(false);


        MainCanvas.GetComponent<Animation>().Play("SlideBackPanel");
        StartCoroutine(WaitForMainMenu(1));
    }

    public void quitApplication()
    {
        Application.Quit();
    }

    #endregion


    // Load and new game script

    public void CreateNewGame()
    {
        if (SaveName.text.Contains("\\"))
        {
            ContainsBackSlash.SetActive(true);
            return;

        }
        if (SaveName.text.Contains("/"))
        {
            Slash.SetActive(true);
            return;
        }
        if (Directory.Exists(SteamManager.SteamPath + "/saves/" + SaveName.text))
        {
            SaveExists = true;
            SaveExistsImage();
            return;
        }

        SaveSystem.SavePlayer(new PlayerProfile { PlayerName = SaveName.text }, false);
        BackToMain();
    }

    List<PlayerProfile> AllSaves = new List<PlayerProfile>();

    //Load Player 

    public void Load()
    {
        AllSaves.Clear();
        if (!Directory.Exists(SteamManager.SteamPath + "/saves/"))
        {
            Directory.CreateDirectory(SteamManager.SteamPath + "/saves/");
        }

        SaveFiles = Directory.GetDirectories(SteamManager.SteamPath + "/saves/");
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
            bool buttonExists = false;

            foreach(Transform child in buttonParent)
            {
                if (child.name == profile.PlayerName)
                    buttonExists = true;
            }
            if (buttonExists)
                continue;

            GameObject button = Instantiate(_buttonTemplate) as GameObject;

            button.name = profile.PlayerName;
            button.SetActive(true);

            button.GetComponent<SavesListButton>().SetText(profile.PlayerName);


            button.transform.SetParent(_buttonTemplate.transform.parent, false);
        }
    }

    public void Reload()
    {
        SaveExists = false;
        _saveExists.SetActive(false);
        ContainsBackSlash.SetActive(false);
        Slash.SetActive(false);
        SaveName.text = "";
    }

    public void SaveExistsImage()
    {
        if (SaveExists == true)
        {
            _saveExists.SetActive(true);
        }
    }
}