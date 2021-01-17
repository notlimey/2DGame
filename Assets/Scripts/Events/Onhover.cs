using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Onhover : MonoBehaviour
{
    public UnityEvent OnHover = new UnityEvent();
    public void Start()
    {
        OnHover.AddListener(Grow);
    }

    public void Grow()
    {
        Debug.Log("HeiHei");
    }
}
