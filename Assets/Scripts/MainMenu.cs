using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        public void Mainmenu()
        {
            SceneManager.LoadScene(0);
        }
        public void SelectOrCreateSave ()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadGame()
        {
            SceneManager.LoadScene(2);
        }

        public void StarterSpot()
        {
            SceneManager.LoadScene(3);
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quitting Game");
        }
    }
}
