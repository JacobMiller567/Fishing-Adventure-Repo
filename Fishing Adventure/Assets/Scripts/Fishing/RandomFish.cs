using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class RandomFish: MonoBehaviour
{
   public PlayerInventory inventory;
   public GameObject inventoryFull;
   private bool isFull;
   //[SerializeField] TextMeshProUGUI fullText;
   



   public void FindRandomFish(float depth)
   {

       if (inventory.fish[inventory.maxFish - 1] != null) // check if last slot has a fish
        {
            Debug.Log("Inventory Is FULL");
          //  inventoryFull.SetActive(true);
          //  fullText.text = "Inventory Full";
         //   isFull = true;
            return;
        }

       // inventoryFull.SetActive(false);
        //fullText.text = " ";

     //   isFull = false;
    
        if (depth <= 5) // Depth of 5
        {
            float chooseFish = Random.Range(0, 7);
            if (chooseFish <= 2) // 43% 
            {
                inventory.fishFound = Resources.LoadAll("GrayFish"); 
            }
            else if (chooseFish > 2 && chooseFish <= 4) // 28.4%
            {
                inventory.fishFound = Resources.LoadAll("BlueFish");
            }
            else if (chooseFish == 5) // 14.3%
            {
                inventory.fishFound = Resources.LoadAll("RedFish");
            }
            else if (chooseFish == 6) // 14.3%
            {
                inventory.fishFound = Resources.LoadAll("Trash");
            }
        }

        if (depth > 5 && depth <= 10) // Depth of 10
        {
            float chooseFish = Random.Range(0, 100);
            if (chooseFish <= 30) // 30%
            {
                inventory.fishFound = Resources.LoadAll("GrayFish");  //SeaSpirit
            }
            else if (chooseFish > 30 && chooseFish <= 55) // 25%
            {
                inventory.fishFound = Resources.LoadAll("BlueFish");//  BlueFish
            }
            else if (chooseFish > 55 && chooseFish <= 75) // 20%
            {
                inventory.fishFound = Resources.LoadAll("RedFish"); //  RedFish
            }

            else if (chooseFish > 75 && chooseFish <= 90) // 15%
            {
                inventory.fishFound = Resources.LoadAll("Crab");
            }
            else if (chooseFish > 90) // 10%
            {
                inventory.fishFound = Resources.LoadAll("Trash");
            }
        }

        if (depth >= 15 && depth < 25) // Depth of 15 - 20
        {
            float chooseFish = Random.Range(0, 100);
            if (chooseFish <= 24) // 25%
            {
                inventory.fishFound = Resources.LoadAll("BlueFish");
            }
            else if (chooseFish > 24 && chooseFish <= 47) // 23%
            {
                inventory.fishFound = Resources.LoadAll("RedFish");
            }
            else if (chooseFish > 47 && chooseFish <= 67) // 20%
            {
                inventory.fishFound = Resources.LoadAll("Carp");
            }
            else if (chooseFish > 67 && chooseFish <= 85) // 18%
            {
                inventory.fishFound = Resources.LoadAll("StripedCarp");
            }
            else if (chooseFish > 85 && chooseFish <= 95) // 10%
            {
                inventory.fishFound = Resources.LoadAll("RainbowCarp");
            }
            else if (chooseFish > 95) // 4%
            {
                inventory.fishFound = Resources.LoadAll("KingCrab");
            }
        }



         if (depth >= 25 && depth < 35) // Depth of 25 - 30
         {
            float chooseFish = Random.Range(0, 100);
            if (chooseFish <= 24) // 25%
            {
                inventory.fishFound = Resources.LoadAll("Crab");
            }
            else if (chooseFish > 24 && chooseFish <= 44) // 20%
            {
                inventory.fishFound = Resources.LoadAll("Carp");
            }
            else if (chooseFish > 44 && chooseFish <= 52) // 8%
            {
                inventory.fishFound = Resources.LoadAll("WoodenChest");
            }
            else if (chooseFish > 52 && chooseFish <= 68) // 16%
            {
                inventory.fishFound = Resources.LoadAll("Eel");
            }
            else if (chooseFish > 68 && chooseFish <= 84) // 16%
            {
                inventory.fishFound = Resources.LoadAll("StripedCarp");
            }
            else if (chooseFish > 84 && chooseFish <= 94) // 10%
            {
                inventory.fishFound = Resources.LoadAll("RainbowCarp");
            }
            else if (chooseFish > 94) // 5%
            {
                inventory.fishFound = Resources.LoadAll("KingCrab");
            }
        }

        if (depth >= 35 && depth < 45) // Depth of 35 - 40
         {
            float chooseFish = Random.Range(0, 100);
            if (chooseFish <= 15) // 16%
            {
                inventory.fishFound = Resources.LoadAll("StripedCarp");
            }
            else if (chooseFish > 15 && chooseFish <= 38) // 23%
            {
                inventory.fishFound = Resources.LoadAll("Bass");
            }
            else if (chooseFish > 38 && chooseFish <= 58) // 20%
            {
                inventory.fishFound = Resources.LoadAll("Tuna");
            }
            else if (chooseFish > 58 && chooseFish <= 63) // 5%
            {
                inventory.fishFound = Resources.LoadAll("GoldenChest");
            }
            else if (chooseFish > 63 && chooseFish <= 79) // 16%
            {
                inventory.fishFound = Resources.LoadAll("Eel");
            }
            else if (chooseFish > 79 && chooseFish <= 85) // 6%
            {
                inventory.fishFound = Resources.LoadAll("KingCrab");
            }
            else if (chooseFish > 85) // 14%
            {
                inventory.fishFound = Resources.LoadAll("JellyFish");
            }
           
        }

         if (depth >= 45 && depth < 55) // Depth of 45 - 50
         {
            float chooseFish = Random.Range(0, 100);

            if (chooseFish <= 19) // 20%
            {
                inventory.fishFound = Resources.LoadAll("Bass");
            }
            else if (chooseFish > 19 && chooseFish <= 39) // 20%
            {
                inventory.fishFound = Resources.LoadAll("Tuna");
            }
            else if (chooseFish > 39 && chooseFish <= 50) // 11%
            {
                inventory.fishFound = Resources.LoadAll("Eel");
            }
            else if (chooseFish > 50 && chooseFish <= 68) // 18%
            {
                inventory.fishFound = Resources.LoadAll("JellyFish");
            }
            else if (chooseFish > 68 && chooseFish <= 74) // 6%
            {
                inventory.fishFound = Resources.LoadAll("GoldenChest");
            }
            else if (chooseFish > 74 && chooseFish <= 89) // 15%
            {
                inventory.fishFound = Resources.LoadAll("SwordFish");
            }
            else if (chooseFish > 89) // 10%
            {
                inventory.fishFound = Resources.LoadAll("Shark");
            }
        }

        if (depth >= 55 && depth < 65) // Depth of 55 - 60
        {
            float chooseFish = Random.Range(0, 100);

            if (chooseFish <= 19) // 20%
            {
                inventory.fishFound = Resources.LoadAll("Tuna");
            }
            else if (chooseFish > 19 && chooseFish <= 39) // 20%
            {
                inventory.fishFound = Resources.LoadAll("JellyFish");
            }
            else if (chooseFish > 39 && chooseFish <= 49) // 10%
            {
                inventory.fishFound = Resources.LoadAll("Shark");
            }
            else if (chooseFish > 49 && chooseFish <= 65) // 16%
            {
                inventory.fishFound = Resources.LoadAll("SwordFish");
            }
            else if (chooseFish > 65 && chooseFish <= 79) // 14%
            {
                inventory.fishFound = Resources.LoadAll("StingRay");
            }
            else if (chooseFish > 79 && chooseFish <= 83) // 4%
            {
                inventory.fishFound = Resources.LoadAll("BloodShark");
            }
            else if (chooseFish > 83) // 16%
            {
                inventory.fishFound = Resources.LoadAll("ClownFish");
            }
        }

        if (depth >= 65 && depth < 75) // Depth of 65 - 70
        {
            float chooseFish = Random.Range(0, 100);

            if (chooseFish <= 24) // 25%
            {
                inventory.fishFound = Resources.LoadAll("JellyFish");
            }
            else if (chooseFish > 24 && chooseFish <= 44) // 20%
            {
                inventory.fishFound = Resources.LoadAll("ClownFish");
            }
            else if (chooseFish > 44 && chooseFish <= 60) // 16%
            {
                inventory.fishFound = Resources.LoadAll("StingRay");
            }
            else if (chooseFish > 60 && chooseFish <= 65) // 5%
            {
                inventory.fishFound = Resources.LoadAll("BloodShark");
            }
            else if (chooseFish > 65 && chooseFish <= 79) // 14%
            {
                inventory.fishFound = Resources.LoadAll("Anchor");
            }
            else if (chooseFish > 79 && chooseFish <= 82) // 3%
            {
                inventory.fishFound = Resources.LoadAll("ZombieFish");
            }
            else if (chooseFish > 82 && chooseFish <= 92) // 10%
            {
                inventory.fishFound = Resources.LoadAll("Shark");
            }
            else if (chooseFish > 92) // 7%
            {
                inventory.fishFound = Resources.LoadAll("SwordFish"); 
            }
        }

        if (depth >= 75 && depth < 85) // Depth of 75 - 80
        {
            float chooseFish = Random.Range(0, 100);

            if (chooseFish <= 29) // 30%
            {
                inventory.fishFound = Resources.LoadAll("ClownFish");
            }
            else if (chooseFish > 29 && chooseFish <= 45) // 16%
            {
                inventory.fishFound = Resources.LoadAll("StingRay");
            }
            else if (chooseFish > 45 && chooseFish <= 56) // 11%
            {
                inventory.fishFound = Resources.LoadAll("AngularFish");
            }
            else if (chooseFish > 56 && chooseFish <= 74) // 18%
            {
                inventory.fishFound = Resources.LoadAll("Anchor");
            }
            else if (chooseFish > 74 && chooseFish <= 78) // 4%
            {
                inventory.fishFound = Resources.LoadAll("ZombieFish");
            }
            else if (chooseFish > 78 && chooseFish <= 94) // 16%
            {
                inventory.fishFound = Resources.LoadAll("PufferFish");
            }
            else if (chooseFish > 94) // 5%
            {
                inventory.fishFound = Resources.LoadAll("BloodShark");
            }
        }

        if (depth >= 85 && depth < 95) // Depth of 85 - 90
        {
            float chooseFish = Random.Range(0, 100);

            if (chooseFish <= 34) // 35%
            {
                inventory.fishFound = Resources.LoadAll("PufferFish");
            }
            else if (chooseFish > 34 && chooseFish <= 52) // 18%
            {
                inventory.fishFound = Resources.LoadAll("Anchor");
            }
            else if (chooseFish > 52 && chooseFish <= 53) // 1%
            {
                inventory.fishFound = Resources.LoadAll("SeaSpirit");
            }
            else if (chooseFish > 53 && chooseFish <= 65) // 12%
            {
                inventory.fishFound = Resources.LoadAll("AngularFish");
            }
            else if (chooseFish > 65 && chooseFish <= 69) // 4%
            {
                inventory.fishFound = Resources.LoadAll("ZombieFish");
            }
            else if (chooseFish > 69 && chooseFish <= 82) // 13%
            {
                inventory.fishFound = Resources.LoadAll("StingRay");
            }
            else if (chooseFish > 82 && chooseFish <= 94) // 12%
            {
                inventory.fishFound = Resources.LoadAll("ClownFish");
            }
            else if (chooseFish > 94) // 6%
            {
                inventory.fishFound = Resources.LoadAll("BloodShark");
            }

        }

        if (depth >= 95 && depth < 105) // Depth of 95 - 100
        {
            float chooseFish = Random.Range(0, 100);

            if (chooseFish <= 34) // 35%
            {
                inventory.fishFound = Resources.LoadAll("PufferFish");
            }
            else if (chooseFish > 34 && chooseFish <= 54) // 20%
            {
                inventory.fishFound = Resources.LoadAll("Anchor");
            }
            else if (chooseFish > 54 && chooseFish <= 55) // 1%
            {
                inventory.fishFound = Resources.LoadAll("SeaSpirit");
            }
            else if (chooseFish > 55 && chooseFish <= 69) // 14%
            {
                inventory.fishFound = Resources.LoadAll("AngularFish");
            }
            else if (chooseFish > 69 && chooseFish <= 70) // 1%
            {
                inventory.fishFound = Resources.LoadAll("SeaSerpent");
            }
            else if (chooseFish > 70 && chooseFish <= 74) // 4%
            {
                inventory.fishFound = Resources.LoadAll("Whale");
            }
            else if (chooseFish > 74 && chooseFish <= 80) // 6%
            {
                inventory.fishFound = Resources.LoadAll("ZombieFish");
            }
            else if (chooseFish > 80 && chooseFish <= 88) // 8%
            {
                inventory.fishFound = Resources.LoadAll("ClownFish");
            }
            else if (chooseFish > 88) // 11%
            {
                inventory.fishFound = Resources.LoadAll("StingRay");
            }
        }

        inventory.fishFound.CopyTo(inventory.displayFish, 0); // keep replacing first item in array
       // inventory.displayFish[0].FishLength = "Small";
        Debug.Log("Fish on line: " + inventory.displayFish[0].FishType);
        Debug.Log("Fish Rariety: " + inventory.displayFish[0].Rariety);

   }




}

       
