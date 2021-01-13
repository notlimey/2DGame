using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    //Is game paused?
    public static bool GameIsPaused;

    //The pause panel which gets activated/deactivated
    public GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("pause"))
        {
            ChangePause();
        }
    }

    public void ChangePause()
    {
        GameIsPaused = !GameIsPaused;
        if (GameIsPaused)
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

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
