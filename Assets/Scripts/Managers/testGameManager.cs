using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoSave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            SerializationManager.Save(StaticClasses.Player, false);
            Debug.Log("saved");
        }
    }
}
