using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shopMenu;
    public PlayerInventory inventoryUpgrades;
    


    public void Shop()
    {
        //SceneManager.LoadScene("Shop");
        shopMenu.SetActive(true);
    }

    public void UpgradeInventorySize() // upgrade fish inventory size to allow you to catch more fish
    {
        if (inventoryUpgrades.playerMoney >= inventoryUpgrades.inventoryUpgradeCost && inventoryUpgrades.inventoryLevel < 3) 
        {
            inventoryUpgrades.playerMoney -= inventoryUpgrades.inventoryUpgradeCost;
            inventoryUpgrades.maxFish += 5; // increase fish amount
            
            //if (inventoryLevel <= 3)
            inventoryUpgrades.inventoryUpgradeCost = inventoryUpgrades.inventoryUpgradeCost * 5; // Max Level: $5000
            inventoryUpgrades.inventoryLevel += 1;
            inventoryUpgrades.IncreaseInventory(); // increase inventory size
            
        }
        else
        {
            Debug.Log("Not enough money for inventory upgrade");
        }

    }

    
    public void UpgradeHookDepth() // upgrade hook depth to catch different fish
    {
        if (inventoryUpgrades.playerMoney >= inventoryUpgrades.depthUpgradeCost && inventoryUpgrades.depthLevel < 10)
        {
            inventoryUpgrades.playerMoney -= inventoryUpgrades.depthUpgradeCost;
            inventoryUpgrades.depthLevel += 1;
            if (inventoryUpgrades.depthLevel <= 1) // first depth upgrade
            {
                inventoryUpgrades.hookDepth += 5f; // 10f
                inventoryUpgrades.depthUpgradeCost = Mathf.Round(inventoryUpgrades.depthUpgradeCost * 1.5f); // 2f
            }
            else // after first depth upgrade
            {
                inventoryUpgrades.hookDepth += 10f; 
                inventoryUpgrades.depthUpgradeCost = Mathf.Round(inventoryUpgrades.depthUpgradeCost * 2f); // 2f
            }
        }
        else
        {
            Debug.Log("Not enough money for depth upgrade");
        }
    }
    
    public void UpgradeHookStrength() // upgrade strength of hook making fish easier to catch
    {
        if (inventoryUpgrades.playerMoney >= inventoryUpgrades.hookUpgradeCost && inventoryUpgrades.HookStrength < 3f)
        {
            inventoryUpgrades.playerMoney -= inventoryUpgrades.hookUpgradeCost;
            inventoryUpgrades.HookStrength += .1f;
            inventoryUpgrades.hookUpgradeCost = inventoryUpgrades.hookUpgradeCost * 3;
            inventoryUpgrades.strengthLevel += 1;
        }
        else
        {
            Debug.Log("Not enough money for strength upgrade");
        }
    }

    public void UpgradeDock() // upgrade size of dock allowing player to use the boat
    {
        if (inventoryUpgrades.playerMoney >= inventoryUpgrades.dockUpgradeCost && inventoryUpgrades.dockUpgraded != true)
        {
            inventoryUpgrades.playerMoney -= inventoryUpgrades.dockUpgradeCost;
            //inventoryUpgrades.HookStrength += .1f;
            //inventoryUpgrades.hookUpgradeCost = inventoryUpgrades.hookUpgradeCost * 2;
            inventoryUpgrades.dockUpgraded = true;
        }

        else if (inventoryUpgrades.dockUpgraded == true)
        {
            Debug.Log("Dock is max level!");
        }

        else
        {
            Debug.Log("Not enough money for dock upgrade");
        }
    }

     public void UpgradeWorker() // upgrade worker allowing for a passive income
    {
        if (inventoryUpgrades.playerMoney >= inventoryUpgrades.workerUpgradeCost && inventoryUpgrades.workerLevel < 5)
        {
            inventoryUpgrades.playerMoney -= inventoryUpgrades.workerUpgradeCost;
            inventoryUpgrades.highered = true;
            inventoryUpgrades.workerUpgradeCost = Mathf.Round(inventoryUpgrades.workerUpgradeCost * 1.5f); 
            inventoryUpgrades.workerLevel += 1;
        }

        else
        {
            Debug.Log("Not enough money for worker upgrade");
        }
    }

    public void Checkout()
    {
        shopMenu.SetActive(false);
    }





}
