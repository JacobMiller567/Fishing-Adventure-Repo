using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMoney : MonoBehaviour
{
    
    [SerializeField] PlayerInventory money;
    [SerializeField] TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        //moneyText.text = money.playerMoney.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + money.playerMoney.ToString();
        
    }
}

