using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StoneObject : MonoBehaviour
{
    
    public GameObject StoneGameObject;
    public string Dialog;
    public bool PlayerInRangeStone;

    float mineTimer;
    float timeToMine = 3f;

    // Start is called before the first frame update
    void Start()
    {
        SelectedProfile.Pickaxe = true;
    }

    // Update is called once per frame
    void Update()
    {

        // Mine stone if you hold down on it for 3 seconds
        if (Input.GetButtonDown("Fire1"))
        {
            mineTimer = Time.time;
        }
        else if (Input.GetButton("Fire1"))
        {
            if (Time.time - mineTimer > timeToMine)
            {
                mineTimer = float.PositiveInfinity;

                DestroyStone();
            }
        }
        else
        {
            mineTimer = float.PositiveInfinity;
        }
    }

    public void DestroyStone()
    {
        if (SelectedProfile.Pickaxe && PlayerInRangeStone)
        {
            Destroy(StoneGameObject);
        }

        return;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRangeStone = true;
        }
    }
}