using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMoney : MonoBehaviour
{ 
    [SerializeField] PlayerInventory money;
    [SerializeField] TextMeshProUGUI moneyText;

    void Update()
    {
        moneyText.text = "$" + money.playerMoney.ToString();
    }
}

