using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackOneScene : MonoBehaviour
{
    public void BackToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
