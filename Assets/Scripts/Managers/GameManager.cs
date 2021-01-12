using System.IO;
using Assets.Scripts.Saving_and_Loading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InputField SaveName;
    public string[] SaveFiles;

    [SerializeField]
    private GameObject _buttonTemplate;

    public void CreateNewGame()
    {
        Player.Username = SaveName.text;
        SerializationManager.SavePlayer(new Player(), true);
    }

    private void Start()
    {
        Load();
    }


    public void Load()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        SaveFiles = Directory.GetDirectories(Application.persistentDataPath + "/saves/");
        foreach (var path in SaveFiles)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var player = SerializationManager.LoadPlayer(path);

                GameObject button = Instantiate(_buttonTemplate) as GameObject;
                button.SetActive(true);

                button.GetComponent<SavesListButton>().SetText(file);

                button.transform.SetParent(_buttonTemplate.transform.parent, false);
            }
        }
    }
}

