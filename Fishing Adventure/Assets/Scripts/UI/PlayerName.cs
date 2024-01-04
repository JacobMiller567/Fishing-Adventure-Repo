using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{
   [SerializeField] private PlayerInventory inventory;
    public new TMP_InputField name;

    void Update()
    {
        inventory.playerName = name.text;      
    }
}
