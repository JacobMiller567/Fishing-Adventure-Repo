using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepthUpgradeCost : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] TextMeshProUGUI upgradeText;

    private float upgradeCost;

    void Start()
    {

    }

    void Update()
    {
        if (inventory.hookDepth < 100f)
        {
            upgradeText.text = "$" + inventory.depthUpgradeCost.ToString(); //+" ("+inventory.hookDepth.ToString()+")";
        }
        else
        {
            upgradeText.text = "Max Level";
        }
        
    }
}
