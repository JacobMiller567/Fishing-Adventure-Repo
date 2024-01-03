using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DockExpansion : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] TextMeshProUGUI upgradeText;

    private float upgradeCost;

    void Start()
    {

    }

    void Update()
    {

        if (inventory.dockUpgraded == true)
        {
            upgradeText.text = "Max Level";
        }
        else
        {
            upgradeText.text = "$" + inventory.dockUpgradeCost.ToString();
        }

    }
}
