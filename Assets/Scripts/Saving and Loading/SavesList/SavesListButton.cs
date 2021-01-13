using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavesListButton : MonoBehaviour
{
    
    public void SetText(string textString)
    {
        gameObject.GetComponentInChildren<Text>().text = textString;
    }

    public void OnClick()
    {
        string Name = gameObject.GetComponentInChildren<Text>().text;
        SelectedProfile.Username = Name;
        string path = Application.persistentDataPath + "/saves/" + Name + "/" + Name + ".dat";
        var player = SerializationManager.LoadPlayer(path);
        SceneManager.LoadSceneAsync(2);
    }


}
