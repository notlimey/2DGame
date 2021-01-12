using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavesListButton : MonoBehaviour
{
    public Button btn;
    
    public void SetText(string textString)
    {
        textString = Player.Username;
    }

    public void OnClick()
    {
        string Name = Player.Username;
        string path = Application.persistentDataPath + "/saves/" + Name + "/" + Name + ".dat";
        var player = SerializationManager.LoadPlayer(path);
        SceneManager.LoadSceneAsync(2);
    }
}
