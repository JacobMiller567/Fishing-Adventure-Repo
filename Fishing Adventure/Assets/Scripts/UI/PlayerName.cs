using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{
   [SerializeField] private PlayerInventory inventory;
    public new TMP_InputField name; // added new so warning would go away

    // Update is called once per frame
    void Update()
    {
        //GetPlayerName();
        inventory.playerName = name.text;      
    }

    /*

    public void GetPlayerName(InputField name)
    {
        inventory.playerName = name.text;
    }
    */


}
