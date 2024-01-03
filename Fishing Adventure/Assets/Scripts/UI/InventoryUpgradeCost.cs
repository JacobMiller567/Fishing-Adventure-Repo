using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUpgradeCost : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] TextMeshProUGUI upgradeText;

    private float upgradeCost;

    void Start()
    {

    }

    void Update()
    {
        if (inventory.inventoryLevel < 3)
        {
            upgradeText.text = "$" + inventory.inventoryUpgradeCost.ToString();
        }
        else
        {
            upgradeText.text = "Max Level";
        }
    }
}
