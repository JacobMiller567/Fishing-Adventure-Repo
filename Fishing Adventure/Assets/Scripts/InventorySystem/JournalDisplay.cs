using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class JournalDisplay : MonoBehaviour
{
    public PlayerInventory inventory;
    public Image fishImage;
    [SerializeField] TextMeshProUGUI fishName;
    [SerializeField] TextMeshProUGUI fishRariety;
    [SerializeField] TextMeshProUGUI sellPrice;
    [SerializeField] TextMeshProUGUI fishSize;
    [SerializeField] TextMeshProUGUI fishWeight;
    [SerializeField] TextMeshProUGUI fishDepth;
    [SerializeField] TextMeshProUGUI description;
    Color rarietyColor;

    void Start()
    {
        rarietyColor = new Color(0, 0, 0, 1); 
    }

    public void DisplayFishInformation(Image icon) // Display clicked fishes information in journal
    {
        var num = 27; 
        if (icon.sprite.name == "Trash" && inventory.fishJournal[0] == true) 
        {
            num = 0;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "GrayFish" && inventory.fishJournal[1] == true) 
        {
            num = 1;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "BlueFish" && inventory.fishJournal[2] == true) 
        {
            num = 2;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "RedFish" && inventory.fishJournal[3] == true) 
        {
            num = 3;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "Crab" && inventory.fishJournal[4] == true) 
        {
            num = 4;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "Carp" && inventory.fishJournal[5] == true) 
        {
            num = 5;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "StripedCarp" && inventory.fishJournal[6] == true) 
        {
            num = 6;
            rarietyColor = new Color(0f, 1f, 0f, 1f); 
        }
        if (icon.sprite.name == "RainbowCarp" && inventory.fishJournal[7] == true) 
        {
            num = 7;
            rarietyColor = new Color(0, 0, 1, 1);
        }
        if (icon.sprite.name == "KingCrab" && inventory.fishJournal[8] == true) 
        {
            num = 8;
            rarietyColor = new Color(1, 0, 1, 1); 
        }
        if (icon.sprite.name == "Eel" && inventory.fishJournal[9] == true) 
        {
            num = 9;
            rarietyColor = new Color(0f, 1f, 0f, 1f); 
        }
        if (icon.sprite.name == "WoodenChest" && inventory.fishJournal[10] == true) 
        {
            num = 10;
            rarietyColor = new Color(0, 0, 1, 1); 
        }
        if (icon.sprite.name == "Bass" && inventory.fishJournal[11] == true) 
        {
            num = 11;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "Tuna" && inventory.fishJournal[12] == true) 
        {
            num = 12;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "GoldenChest" && inventory.fishJournal[13] == true) 
        {
            num = 13;
            rarietyColor = new Color(1, 0, 1, 1); 
        }
        if (icon.sprite.name == "JellyFish" && inventory.fishJournal[14] == true) 
        {
            num = 14;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "Shark" && inventory.fishJournal[15] == true) 
        {
            num = 15;
            rarietyColor = new Color(0, 0, 1, 1); 
        }
        if (icon.sprite.name == "SwordFish" && inventory.fishJournal[16] == true) 
        {
            num = 16;
            rarietyColor = new Color(0f, 1f, 0f, 1f); 
        }
        if (icon.sprite.name == "ClownFish" && inventory.fishJournal[17] == true) 
        {
            num = 17;
            rarietyColor = new Color(0, 0, 0, 1); 
        }
        if (icon.sprite.name == "StingRay" && inventory.fishJournal[18] == true) 
        {
            num = 18;
            rarietyColor = new Color(0f, 1f, 0f, 1f); 
        }
        if (icon.sprite.name == "BloodShark" && inventory.fishJournal[19] == true) 
        {
            num = 19;
            rarietyColor = new Color(1, 0, 1, 1); 
        }
        if (icon.sprite.name == "Anchor" && inventory.fishJournal[20] == true) 
        {
            num = 20;
            rarietyColor = new Color(0f, 1f, 0f, 1f); 
        }
        if (icon.sprite.name == "ZombieFish" && inventory.fishJournal[21] == true) 
        {
            num = 21;
            rarietyColor = new Color(1f, 0f, 1f, 1f); 
        }
        if (icon.sprite.name == "AngularFish" && inventory.fishJournal[22] == true) 
        {
            num = 22;
            rarietyColor = new Color(0f, 0f, 1f, 1f); 
        }
        if (icon.sprite.name == "PufferFish" && inventory.fishJournal[23] == true) 
        {
            num = 23;
            rarietyColor = new Color(0f, 0f, 0f, 1f); 
        }
        if (icon.sprite.name == "SeaSpirit" && inventory.fishJournal[24] == true) 
        {
            num = 24;
            rarietyColor = new Color(1f, 0.92f, 0.016f, 1f); 
        }
        if (icon.sprite.name == "Whale" && inventory.fishJournal[25] == true) 
        {
            num = 25;
            rarietyColor = new Color(1, 0, 1, 1); 
        }
        if (icon.sprite.name == "SeaSerpent" && inventory.fishJournal[26] == true) 
        {
            num = 26;
            rarietyColor = new Color(1f, 0.92f, 0.016f, 1f); 
        }
    
        fishImage.sprite = inventory.allFishJournal[num].Icon; 
        fishName.text = inventory.allFishJournal[num].FishType; 
        fishRariety.text = inventory.allFishJournal[num].Rariety; 
        fishRariety.color = rarietyColor; 
        sellPrice.text = "Sell Price: $" + inventory.allFishJournal[num].SellPrice; 
        fishSize.text = "Size: " + inventory.allFishJournal[num].FishSize + " in"; 
        fishWeight.text = "Weight: " + inventory.allFishJournal[num].FishWeight + " lbs"; 
        fishDepth.text = "Depth: " + inventory.allFishJournal[num].Depth + "m"; 
        description.text = inventory.allFishJournal[num].Description; 
    }
   
}
