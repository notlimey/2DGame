using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Saving_and_Loading
{
    [System.Serializable]
    public class PlayerProfile
    {
        public float[] Position;
        public string PlayerName;
        public List<Item> items;
    }
}