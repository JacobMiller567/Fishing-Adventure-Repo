using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CreateAssetMenu]
public class PlayerInventory : ScriptableObject 
{
    public string playerName = "Player Name"; 
    public float playerMoney; 
    public float HookStrength;
    public float hookDepth = 5f;
    public int maxFish = 5; 
    public int count; 
    public bool inventoryFull = false;
    
    // Upgrades //
    public float inventoryUpgradeCost = 75f;
    public float depthUpgradeCost = 40f;
    public float hookUpgradeCost = 40f;
    public float dockUpgradeCost = 115f;
    public bool dockUpgraded;
    public int strengthLevel = 0;
    public int inventoryLevel = 0;
    public int depthLevel = 0;


    public Object[] fishFound; // Array that stores fish that is on the line

    public FishData[] displayFish; // Array that displays fish

    public FishData[] fish; // Array that stores fish data
    public string[] fishLengthHolder; // Array that stores fish length

    // Journal: // 
    public bool[] fishJournal; // Stores true or false for if fish has been caught
    public FishData[] allFishJournal; // Stores all the fish in the game. Used to pull information from for journal

    // Quest System: //
    public int CountFish; 
    public bool QuestActive;
    public bool QuestComplete;
    public bool SpikedHook; // Quest reward that stops fish from taking bait

    //Pirate Quest//
    public bool PirateQuest;
    public bool CaughtSpirit;
    public bool BoatUpgrade; // Quest reward that makes boat 50% faster 1.5 --> 2.25

    // Boat Upgrade //
    public float boatFuel;

    // NPC Worker: //
    public bool highered;
    public int workerLevel = 0;
    public float workerUpgradeCost = 250f;

    // Keep Player Stats Info
    public float totalCatches = 0f;
    public float totalExcapes = 0f;
    public float totalMoney = 0f;


    // Store Game Volume
    public float musicVolume = 0.18f;
    public bool gameSound = true;


    public void AddFish()
    {
        if (fish[maxFish - 1] != null)
        {
            return;
        }

        for (int i = 0; i < maxFish; i++)
       {

            if (fish[i] == null)
            {
                totalCatches += 1;
                fishFound.CopyTo(fish, i);
                count = i;
                fish[i].isCaught = true; // Fish type has been recorded.
                UpdateJournal(fish[i]);

                if (fish[i].FishType == "Sea Spirit")
                {
                    if (PirateQuest == true)
                    {
                        CaughtSpirit = true;
                    }
                }

                float chooseSize = Random.Range(0, 100);

                if (chooseSize >= 0 && chooseSize <= 4) // 5% fish is tiny
                {
                    fishLengthHolder[i] = "Tiny";
                }
                if (chooseSize >= 5 && chooseSize < 25) // 20% fish is small
                {
                    fishLengthHolder[i] = "Small";
                }
                if (chooseSize >= 25 && chooseSize < 75) // 50% fish is average 
                {
                    fishLengthHolder[i] = "Average";
                }
                if (chooseSize >= 75 && chooseSize < 95) // 20% fish is large 
                {
                    fishLengthHolder[i] = "Large";

                }
                if (chooseSize >= 95) // 5% fish is huge
                {
                    fishLengthHolder[i] = "Huge";
                }

                return;
            }
       }

        if (count <= maxFish) 
        {
            fishFound.CopyTo(fish, count); 
            count += 1; 
            if (count >= maxFish) 
            {
                count = 0;
            }
            return;
        }
    }

    public void SellFish() 
    {
        float profit = 0; 

        for (int i = 0; i < fish.Length; i++)
        {
            
            if (fish[i] == null) 
            {
                break;
            }

            else if (fishLengthHolder[i] == "Tiny")
            {
                Debug.Log(fish[i].FishType + ": Tiny"); 
                profit += Mathf.Round(fish[i].SellPrice - (fish[i].SellPrice * 0.25f)); // subtract 25% from sell price
                fish[i] = null;
                fishLengthHolder[i] = null;
            }
            else if (fishLengthHolder[i] == "Small")
            {
                Debug.Log(fish[i].FishType + ": Small"); 
                profit += Mathf.Round(fish[i].SellPrice - (fish[i].SellPrice * 0.15f)); // subtract 15% from sell price
                fish[i] = null;
                fishLengthHolder[i] = null;
            }
            else if (fishLengthHolder[i] == "Large")
            {
                Debug.Log(fish[i].FishType + ": Large"); 
                profit += Mathf.Round(fish[i].SellPrice + (fish[i].SellPrice * 0.15f)); // add 15% more to sell price
                fish[i] = null;
                fishLengthHolder[i] = null;
            }
            else if (fishLengthHolder[i] == "Huge")
            {
                Debug.Log(fish[i].FishType + ": Huge"); 
                profit += Mathf.Round(fish[i].SellPrice + (fish[i].SellPrice * 0.25f)); // add 25% more to sell price
                fish[i] = null;
                fishLengthHolder[i] = null;
            }
            else if (fishLengthHolder[i] == "Average")
            {
                Debug.Log(fish[i].FishType + ": Average"); 
                profit += fish[i].SellPrice; // add fish sell price
                fish[i] = null;
                fishLengthHolder[i] = null;
            }
        }
            playerMoney += profit;
            totalMoney += profit; 
            inventoryFull = false; 
            count = 0; 
            return;
    }

    public void IncreaseInventory() // Increase inventory size
    {
        FishData[] fishSave = new FishData[maxFish - 5];

        System.Array.Copy(fish, fishSave, maxFish - 5); 

        fish = new FishData[maxFish];

        for (int i = 0; i < fishSave.Length; i++)
        {
            fishSave.CopyTo(fish, i); 
            if (fish[maxFish - 5] == null)
            {
                break;
            }
        }

    }

    public Sprite GetFishIcon()
    { 
        for (int i = 0; i < maxFish; i++)
        {
            if (fish[i] == null)
            {
                break;
            }
        }

        return fish[0].Icon;
    }


    public void UpdateJournal(FishData record) // Update fishing journal
    {
        if (record.FishType == "Trash")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[0] = true;
        }
        if (record.FishType == "Gray Fish")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[1] = true;
        }
        if (record.FishType == "Blue Fish")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[2] = true;
        }
        if (record.FishType == "Red Fish")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[3] = true;
        }
        if (record.FishType == "Crab")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[4] = true;
        }
        if (record.FishType == "Carp")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[5] = true;
        }
        if (record.FishType == "Striped Carp")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[6] = true;
        }
        if (record.FishType == "Rainbow Carp")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[7] = true;
        }
        if (record.FishType == "King Crab")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[8] = true;
        }
        if (record.FishType == "Electric Eel")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[9] = true;
        }
        if (record.FishType == "Wooden Chest")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[10] = true;
        }
        if (record.FishType == "Bass")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[11] = true;
        }
        if (record.FishType == "Tuna")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[12] = true;
        }
        if (record.FishType == "Golden Chest")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[13] = true;
        }
        if (record.FishType == "Jellyfish")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[14] = true;
        }
        if (record.FishType == "Shark")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[15] = true;
        }
        if (record.FishType == "Swordfish")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[16] = true;
        }
        if (record.FishType == "Clownfish")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[17] = true;
        }
        if (record.FishType == "Stringray")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[18] = true;
        }
        if (record.FishType == "Blood Shark")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[19] = true;
        }
        if (record.FishType == "Anchor")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[20] = true;
        }
        if (record.FishType == "Zombie Fish")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[21] = true;
        }
        if (record.FishType == "Anglerfish")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[22] = true;
        }
        if (record.FishType == "Pufferfish")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[23] = true;
        }
        if (record.FishType == "Sea Spirit")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[24] = true;
        }
        if (record.FishType == "Whale")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[25] = true;
        }
        if (record.FishType == "Sea Serpent")
        {
            Debug.Log("Fish Updated!!!");
            fishJournal[26] = true;
        }
    }




}
