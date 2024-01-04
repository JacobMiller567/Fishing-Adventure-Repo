using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrengthUpgradeCost : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] TextMeshProUGUI upgradeText;

    private float upgradeCost;

    void Update()
    {
        if (inventory.HookStrength < 3f)
        {
            upgradeText.text = "$" + inventory.hookUpgradeCost.ToString();
        }
        else
        {
            upgradeText.text = "Max Level";
        }
    }
}
