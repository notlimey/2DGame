using UnityEngine;

namespace Assets.Scripts.Saving_and_Loading
{
    [System.Serializable]
    public class PlayerProfile
    {
        public float[] Position;
        public string PlayerName;
        
        public PlayerProfile([System.Runtime.InteropServices.OptionalAttribute] Player player)
        {
            if (player != null)
            {
                Position = new float[3];
                Position[0] = player.transform.position.x;
                Position[1] = player.transform.position.y;
                Position[2] = player.transform.position.z;
            }
            else
            {
                Debug.Log("Player Don't exist No changes");
            }
        }
    }
}