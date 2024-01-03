using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PirateNPC : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private GameObject Quest;
    [SerializeField] private GameObject QuestHolder;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private GameObject dialogue;
    //[SerializeField] private GameObject dialogueComplete;

    private bool ActiveQuest = false;
    [SerializeField] TextMeshProUGUI questText;
    public bool updateQuest;
    public bool questFinished;

     public string quest2 = "Catch Sea Spirit?!";
  
    void Start()
    {
        ActiveQuest = inventory.PirateQuest;//inventory.QuestActive;
        updateQuest = true;
        questFinished = inventory.CaughtSpirit;


        if (ActiveQuest != true)
        {
            QuestHolder.SetActive(false);
        }
    }

   
    public void Update()
    {
        if ((player.position - transform.position).magnitude < 3f && inventory.QuestComplete == true)
        {
            QuestHolder.SetActive(true);
            Quest.SetActive(true);
            ActiveQuest = true;
            inventory.PirateQuest = true;
            updateQuest = true;
            dialogue.SetActive(true);
        }
        else
        {
            dialogue.SetActive(false);

        }

        if (inventory.PirateQuest == true && updateQuest == true)
        {

            //quests.Add(questDialogue);
            questText.text = quest2;
            updateQuest = false;
        }



         if (inventory.CaughtSpirit == true)
        {
            
            if ((player.position - transform.position).magnitude < 3f)
            {
               // dialogueComplete.SetActive(true);

                if (inventory.PirateQuest == true)
                {
                    // Reward:
                        // $1400
                        // Faster boat speed 1.5 --> 2.25
                    inventory.playerMoney += 1400f;
                    inventory.totalMoney += 1400f;
                    inventory.PirateQuest = false;
                    inventory.BoatUpgrade = true;
                    ActiveQuest = false;
                    inventory.CaughtSpirit = false;
                }

            }

            else
            {
               // dialogueComplete.SetActive(false);

            }
        }

        if (ActiveQuest != true)
        {
            QuestHolder.SetActive(false);
        } 
    }



}
