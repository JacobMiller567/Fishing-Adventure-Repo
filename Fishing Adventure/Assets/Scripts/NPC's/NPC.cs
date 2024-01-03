using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private GameObject Interact;
    [SerializeField] private GameObject QuestHolder;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject dialogueComplete;
    public bool ActiveQuest = false;
    public int FishCounter;
    public List<string> quests = new List<string>();
    [SerializeField] TextMeshProUGUI questText;
    public bool updateQuest;

    // Quest Reward: 0% chance fish takes your bait and leaves
    //public string questDialogue = "If you can prove that you are a good fisherman by catching 20 fish, then I will teach you a new fishing technique"; 
    public string quest1 = "Catch 20 Fish";
    // Reward 2?: Fisherman NPC will catch fish for you over time

    public void Start()
    {
        FishCounter = inventory.CountFish; // get saved fish count
        updateQuest = true;
        ActiveQuest = inventory.QuestActive;
        //ActiveQuest = inventory.QuestActive;

        if (ActiveQuest != true)
        {
            QuestHolder.SetActive(false);
        }
    } 


    public void Update()
    {
        if ((player.position - transform.position).magnitude < 0.75f && inventory.QuestComplete == false)
        {
            QuestHolder.SetActive(true);
            Interact.SetActive(true);
            ActiveQuest = true;
            inventory.QuestActive = true;
            updateQuest = true;
            dialogue.SetActive(true);
        }
        else
        {
            //Interact.SetActive(false);
            dialogue.SetActive(false);

        }

        if (inventory.QuestActive == true && updateQuest == true)
        {

            //quests.Add(questDialogue);
            questText.text = quest1 + ": " + FishCounter.ToString() + "/20";
            updateQuest = false;
        }

        if (FishCounter == 20 && inventory.QuestActive == true)
        {
            UpdateDialogue();
        }

        if (inventory.QuestComplete == true)
        {
            
            if ((player.position - transform.position).magnitude < 0.75f)
            {
                dialogueComplete.SetActive(true);

                if (inventory.QuestActive == true)
                {
                    inventory.SpikedHook = true;
                    inventory.playerMoney += 150f;
                    inventory.totalMoney += 150f;
                    inventory.QuestActive = false;
                    ActiveQuest = false;
                }

            }
            else
            {
                dialogueComplete.SetActive(false);

            }
        }


        if (ActiveQuest != true)
        {
            QuestHolder.SetActive(false);
        } 
    }

    public void UpdateDialogue()
    {
        if (inventory.QuestComplete == false)
        {
            inventory.QuestComplete = true;
            dialogue.SetActive(false);
        }

    }
}
