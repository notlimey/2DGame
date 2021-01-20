using System.Collections;
using UnityEngine;

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

    Onhover hover;

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
}