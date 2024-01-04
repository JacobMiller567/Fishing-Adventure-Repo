using System;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public PlayerData PlayerData = new PlayerData();
    public PlayerInventory TestInventory = ScriptableObject.CreateInstance<PlayerInventory>();

}
