using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saving_and_Loading;
using UnityEngine;

public class DevConsole : MonoBehaviour
{
    //Is game paused?
    public static bool _gameIsPaused;

    //The pause panel which gets activated/deactivated
    public GameObject PausePanel;

    private PlayerProfile profile;

    //For saving the player on leave
    public GameObject player;

    void Start()
    {
        _gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            ChangePause();
        }
    }

    public void ChangePause()
    {
        _gameIsPaused = !_gameIsPaused;
        if (_gameIsPaused)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    //Resume the Game 
    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
