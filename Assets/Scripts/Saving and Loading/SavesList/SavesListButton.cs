using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavesListButton : MonoBehaviour
{
    [SerializeField]
    private Text myText;

    public void SetText(string textString)
    {
        myText.text = textString;
    }

    public void OnClick()
    {
        string name = myText.text;
        string path = Application.persistentDataPath + "/saves/" + name + "/" + name + ".dat";
        var player = SerializationManager.Load(path);
        StaticClasses.Player = player;
        SceneManager.LoadSceneAsync(2);
    }
}
