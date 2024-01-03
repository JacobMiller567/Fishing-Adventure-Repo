using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
//public class WeaponData : ScriptableObject, ISerializationCallbackReceiver
// public enum FishData {YellowFish, RedFish}
[CreateAssetMenu]
public class FishData : ScriptableObject
{
    public string FishType;
    public Sprite Icon;
    public float FishSize; // {get; set};
    public float FishWeight;
    public float Depth;
    public string Rariety;
    public float SellPrice;
    public string Description;
    public bool isCaught;

}


