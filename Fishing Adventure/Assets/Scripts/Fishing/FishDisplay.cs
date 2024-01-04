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
        fishImage.sprite = inventory.displayFish[0].Icon; 
        nameText.text = inventory.displayFish[0].FishType; 
        rarietyText.text = inventory.displayFish[0].Rariety; 
        sellText.text = "$ " + inventory.displayFish[0].SellPrice;
        sizeText.text = inventory.fishLengthHolder[inventory.count]; 
        StartCoroutine(HideDisplay());
    }

    IEnumerator HideDisplay()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
    }


}