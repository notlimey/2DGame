using Assets.Scripts.Saving_and_Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    //Is game paused?
    public static bool GameIsPaused;

    //The pause panel which gets activated/deactivated
    public GameObject PausePanel;

    //For saving the player on leave
    public GameObject player;

    //For activation and deactivation of the HUD
    public GameObject HUD;

    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused = false;
        HUD.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("pause"))
        {
            ChangePause();
        }
    }

    //Changing if the game is paused or not
    public void ChangePause()
    {
        if (!InventoryManager.InventoryActive)
        {
            GameIsPaused = !GameIsPaused;
            if (GameIsPaused)
            {
                PausePanel.SetActive(true);
                HUD.SetActive(false);
                Time.timeScale = 0f;
            }
            else
            {
                PausePanel.SetActive(false);
                HUD.SetActive(true);
                Time.timeScale = 1f;
            }
        }
        else return;
    }


    //Resume the Game 
    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    //The float array which the player position is saved as
    float[] PlayerPosition = new float[3];

    //Before quitting the game we want to save
    public void SaveAndQuitToMain()
    {
        PlayerPosition[0] = player.transform.position.x;
        PlayerPosition[1] = player.transform.position.y;
        PlayerPosition[2] = player.transform.position.z;
        SaveSystem.SavePlayer(new PlayerProfile { PlayerName = SelectedProfile.Username, Position = PlayerPosition }, false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
