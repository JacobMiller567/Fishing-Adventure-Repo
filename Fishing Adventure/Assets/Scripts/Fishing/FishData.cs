using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class FishData : ScriptableObject
{
    public string FishType;
    public Sprite Icon;
    public float FishSize; 
    public float FishWeight;
    public float Depth;
    public string Rariety;
    public float SellPrice;
    public string Description;
    public bool isCaught;

}


