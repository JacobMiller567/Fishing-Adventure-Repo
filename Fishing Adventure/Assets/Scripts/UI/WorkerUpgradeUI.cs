using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkerUpgradeUI : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] TextMeshProUGUI upgradeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.workerLevel < 5)
        {
            upgradeText.text = "$" + inventory.workerUpgradeCost.ToString();
        }
        else
        {
            upgradeText.text = "Max Level";
        }
        
    }
}
