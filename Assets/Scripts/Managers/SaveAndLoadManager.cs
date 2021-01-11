using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject CameraObject;

    
    void Start()
    {
        StartCoroutine(AutoSave());
    }

    private void Update()
    {
        
    }

    IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            SerializationManager.Save(StaticClasses.Player, StaticClasses.Data.Position, false);
            Debug.Log("AutoSave");
        }
    }

}
