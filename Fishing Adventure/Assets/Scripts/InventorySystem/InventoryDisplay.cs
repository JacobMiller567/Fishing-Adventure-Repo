using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{

    public PlayerInventory inventory;
    public Image[] slotImage;


    public void Start()
    {
        UpdateInventoryDisplay();
    }


    public void Update()
    {
        UpdateInventoryDisplay();
    }

    public void UpdateInventoryDisplay()
    {
        for (int i = 0; i < inventory.maxFish; i++)
        {

            if (inventory.fish[i] == null)
            {
                slotImage[i].sprite = null;
                slotImage[i].color = Color.white;
            }
            else
            {
                slotImage[i].sprite = inventory.fish[i].Icon;
            }

        }
    }
    
}
