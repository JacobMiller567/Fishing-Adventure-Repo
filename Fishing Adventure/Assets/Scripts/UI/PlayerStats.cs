using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI depthText;
    [SerializeField] TextMeshProUGUI strengthText;
    [SerializeField] TextMeshProUGUI totalCatchesText;
    [SerializeField] TextMeshProUGUI totalEarnedText;
    [SerializeField] TextMeshProUGUI FishExcapedText;

    void Start()
    {
        
    }

    void Update()
    {
        nameText.text = inventory.playerName;
        depthText.text = "Fishing Depth: " + inventory.hookDepth.ToString() + "m";
        strengthText.text = "Strength Level: " + inventory.strengthLevel.ToString();
        totalCatchesText.text = "Total Catches: " + inventory.totalCatches.ToString();
        totalEarnedText.text = "Total Earned: " + "$"+inventory.totalMoney.ToString();
        FishExcapedText.text = "Fish Escaped: " + inventory.totalExcapes.ToString();
        
    }
}
