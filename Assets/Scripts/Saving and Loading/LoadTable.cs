using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("listOfSavesContainer");
        entryTemplate = transform.Find("listOfSaves");
    }

    // sources for tomorrow
    // https://www.youtube.com/watch?v=iAbaqGYdnyI
    // 
}
