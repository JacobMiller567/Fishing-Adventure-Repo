using System;
using UnityEngine;

//namespace SaveLoad
//{

    [System.Serializable]
    public class SaveData 
    {
        public PlayerData PlayerData = new PlayerData();
        public PlayerInventory TestInventory = ScriptableObject.CreateInstance<PlayerInventory>(); //new PlayerInventory(); //PlayerInventory.);

    }
//}
