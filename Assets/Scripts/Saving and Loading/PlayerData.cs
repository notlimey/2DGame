using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    
    public void Position()
    {
        if (Player.player = null)
        {
            Debug.Log("Object = null");
        }
        else
        {
            Debug.Log("Object exists");
        }
    }
}