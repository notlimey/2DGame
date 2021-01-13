using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public TMP_Text userName;

    void Start()
    {
        userName.text = SelectedProfile.Username;
    }
}
