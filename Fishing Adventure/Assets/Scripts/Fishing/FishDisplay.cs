using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class FishDisplay : MonoBehaviour
{
    public PlayerInventory inventory;
    public Image fishImage;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI rarietyText;
    [SerializeField] TextMeshProUGUI sellText;
    [SerializeField] TextMeshProUGUI sizeText;

    public void ShowFish() // Display fish once it has been caught
    {
        fishImage.sprite = inventory.displayFish[0].Icon; // Display fish sprite
        nameText.text = inventory.displayFish[0].FishType; // Display fish name
        rarietyText.text = inventory.displayFish[0].Rariety; // Display fish rariety
        sellText.text = "$ " + inventory.displayFish[0].SellPrice; // Display fish sell price
      //  sizeText.text = inventory.displayFish[0].FishLength;
        sizeText.text = inventory.fishLengthHolder[inventory.count]; // Display fish size

        StartCoroutine(HideDisplay());
    }

    IEnumerator HideDisplay() // or player clicks "x" button 
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
    }


}