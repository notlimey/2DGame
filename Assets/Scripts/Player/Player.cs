using System.Collections;
using Assets.Scripts.Saving_and_Loading;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _cheatsActive;
    void Start()
    {
        LoadMyPlayer();
        StartCoroutine(AutoSave());
    }

    float[] PlayerPosition = new float[3];


    IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            PlayerPosition[0] = transform.position.x;
            PlayerPosition[1] = transform.position.y;
            PlayerPosition[2] = transform.position.z;
            SaveSystem.SavePlayer(new PlayerProfile { PlayerName = SelectedProfile.Username, Position = PlayerPosition }, false);
        }
    }

    public void LoadMyPlayer()
    {
        string path = Application.persistentDataPath + "/saves/" + SelectedProfile.Username + "/" + SelectedProfile.Username + ".dat";
        PlayerProfile data = SaveSystem.LoadPlayer(path);
        Debug.Log(data.DevConsole);
        Debug.Log(_cheatsActive);

        if (data.Position != null)
        {
            Vector3 position;
            position.x = data.Position[0];
            position.y = data.Position[1];
            position.z = data.Position[2];

            transform.position = position;
        }
    }

    
}
