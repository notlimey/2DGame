﻿using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavesListButton : MonoBehaviour
{
    public void SetText(string textString)
    {
        gameObject.GetComponentInChildren<TMP_Text>().text = textString;
    }

    public void OnClick()
    {
        string Name = gameObject.GetComponentInChildren<TMP_Text>().text;
        SelectedProfile.Username = Name;
        string path = SteamManager.SteamPath + "/saves/" + Name + "/" + Name + ".dat";
        SaveSystem.LoadPlayer(path);
        SceneManager.LoadSceneAsync(1);
    }
}
