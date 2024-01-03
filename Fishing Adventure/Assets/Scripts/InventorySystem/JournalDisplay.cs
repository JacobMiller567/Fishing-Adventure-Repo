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
        rarietyColor = new Color(0, 0, 0, 1); // Black color
    }


    public void DisplayFishInformation(Image icon) // Display clicked fishes information in journal
    {
        var num = 27; // Default is unknown fish
        if (icon.sprite.name == "Trash" && inventory.fishJournal[0] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 0;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "GrayFish" && inventory.fishJournal[1] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 1;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "BlueFish" && inventory.fishJournal[2] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 2;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "RedFish" && inventory.fishJournal[3] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 3;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "Crab" && inventory.fishJournal[4] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 4;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "Carp" && inventory.fishJournal[5] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 5;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "StripedCarp" && inventory.fishJournal[6] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 6;
            rarietyColor = new Color(0f, 1f, 0f, 1f); // Green color
        }
        if (icon.sprite.name == "RainbowCarp" && inventory.fishJournal[7] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 7;
            rarietyColor = new Color(0, 0, 1, 1); // Blue color
        }
        if (icon.sprite.name == "KingCrab" && inventory.fishJournal[8] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 8;
            rarietyColor = new Color(1, 0, 1, 1); // Magenta color
        }
        if (icon.sprite.name == "Eel" && inventory.fishJournal[9] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 9;
            rarietyColor = new Color(0f, 1f, 0f, 1f); // Green color
        }
        if (icon.sprite.name == "WoodenChest" && inventory.fishJournal[10] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 10;
            rarietyColor = new Color(0, 0, 1, 1); // Blue color
        }
        if (icon.sprite.name == "Bass" && inventory.fishJournal[11] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 11;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "Tuna" && inventory.fishJournal[12] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 12;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "GoldenChest" && inventory.fishJournal[13] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 13;
            rarietyColor = new Color(1, 0, 1, 1); // Magenta color
        }
        if (icon.sprite.name == "JellyFish" && inventory.fishJournal[14] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 14;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "Shark" && inventory.fishJournal[15] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 15;
            rarietyColor = new Color(0, 0, 1, 1); // Blue color
        }
        if (icon.sprite.name == "SwordFish" && inventory.fishJournal[16] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 16;
            rarietyColor = new Color(0f, 1f, 0f, 1f); // Green color
        }
        if (icon.sprite.name == "ClownFish" && inventory.fishJournal[17] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 17;
            rarietyColor = new Color(0, 0, 0, 1); // Black color
        }
        if (icon.sprite.name == "StingRay" && inventory.fishJournal[18] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 18;
            rarietyColor = new Color(0f, 1f, 0f, 1f); // Green color
        }
        if (icon.sprite.name == "BloodShark" && inventory.fishJournal[19] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 19;
            rarietyColor = new Color(1, 0, 1, 1); // Magenta color
        }
        if (icon.sprite.name == "Anchor" && inventory.fishJournal[20] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 20;
            rarietyColor = new Color(0f, 1f, 0f, 1f); // Green color
        }
        if (icon.sprite.name == "ZombieFish" && inventory.fishJournal[21] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 21;
            rarietyColor = new Color(1f, 0f, 1f, 1f); // Magenta color
        }
        if (icon.sprite.name == "AngularFish" && inventory.fishJournal[22] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 22;
            rarietyColor = new Color(0f, 0f, 1f, 1f); // Blue color
        }
        if (icon.sprite.name == "PufferFish" && inventory.fishJournal[23] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 23;
            rarietyColor = new Color(0f, 0f, 0f, 1f); // Black color
        }
        if (icon.sprite.name == "SeaSpirit" && inventory.fishJournal[24] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 24;
            rarietyColor = new Color(1f, 0.92f, 0.016f, 1f); // Yellow color
        }
        if (icon.sprite.name == "Whale" && inventory.fishJournal[25] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 25;
            rarietyColor = new Color(1, 0, 1, 1); // Magenta color
        }
        if (icon.sprite.name == "SeaSerpent" && inventory.fishJournal[26] == true) //ADD:  Check if player has found the fish. If not don't show info.
        {
            num = 26;
            rarietyColor = new Color(1f, 0.92f, 0.016f, 1f); // Yellow color
        }
    
        fishImage.sprite = inventory.allFishJournal[num].Icon; // Display fish sprite
        fishName.text = inventory.allFishJournal[num].FishType; // Display fish name
        fishRariety.text = inventory.allFishJournal[num].Rariety; // Display fish rariety
        fishRariety.color = rarietyColor; //  = new Color32(1, 0, 0, 1);
        sellPrice.text = "Sell Price: $" + inventory.allFishJournal[num].SellPrice; // Display fish sell price
        fishSize.text = "Size: " + inventory.allFishJournal[num].FishSize + " in"; // Display fish size
        fishWeight.text = "Weight: " + inventory.allFishJournal[num].FishWeight + " lbs"; // Display fish weight
        fishDepth.text = "Depth: " + inventory.allFishJournal[num].Depth + "m"; // Display fish depth
        description.text = inventory.allFishJournal[num].Description; // Display fish description 

    }

   
}
