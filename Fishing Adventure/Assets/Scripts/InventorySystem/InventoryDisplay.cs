using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{

    public PlayerInventory inventory;
    public Image[] slotImage;
    //private bool show;



    public void Start()
    {
        //slotImage[0].sprite = inventory.GetFishIcon(); // make slot image same as fish sprite
        //show = false;
        UpdateInventoryDisplay();
    }


    public void Update()
    {
        UpdateInventoryDisplay();

        /*
        if (Input.GetKeyDown("tab") && !show)
        {
            show = true;
            UpdateInventoryDisplay();
        }
        else if (Input.GetKeyDown("tab") && show)
        {
            show = false;
        }
        */
    }

    public void UpdateInventoryDisplay()
    {
       // imagesinventory.fish[i].Icon
       //images[0] = inventory.GetFishIcon();

        for (int i = 0; i < inventory.maxFish; i++)
        {

            if (inventory.fish[i] == null)
            {
                slotImage[i].sprite = null;
                slotImage[i].color = Color.white; // make available slots white
                //break;
            }
            else
            {
                slotImage[i].sprite = inventory.fish[i].Icon; //inventory.GetFishIcon();
            }

        }


    }

    /*
    
    public PlayerInventory inventory;
    public FishDisplay[] slots;

   private void Start()
    {
        UpdateInventory();
    }

    void UpdateInventory()
    {
        for (int i = 0; i < inventory.fish.Length; i++)
        {
            if (i < inventory.fishHolder.Count)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].UpdateFishDisplay(inventory.fishHolder[i].FishType.Icon, i);

            }
            else
            {
                slots[i].gameObject.SetActive(false);
            }
        }
        
    }
    */
    
}
