using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkerNPC : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] public Transform player;
    [SerializeField] TextMeshProUGUI incomeText;

    [SerializeField] private GameObject image;
    public float workPrice = 250f;
    private bool working = false;
    public float income = 6f;

    void Update()
    {
        incomeText.text = "$" + income.ToString() + "/min";

        // Upgrade Costs: $250, $375, $563, $845, $1268

        // Level 1: $6 a minute --> $360 an hour
        if (inventory.workerLevel == 1)
        {
            income = 6f;
        }
        // Level 2: $12 a minute --> $720 an hour
        if (inventory.workerLevel == 2)
        {
            income = 12f;
        }
        // Level 3: $20 a minute --> $1200 an hour
        if (inventory.workerLevel == 3)
        {
            income = 20f;
        }
        // Level 4: $30 a minute --> $1800 an hour
        if (inventory.workerLevel == 4)
        {
            income = 30f;
        }
        // Level 5: $40 a minute --> $2400 an hour
        if (inventory.workerLevel == 5)
        {
            income = 40f;
        }

        if ((player.position - transform.position).magnitude < 0.35f && inventory.highered) 
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        } 

        if (inventory.highered && working == false)
        {
            working = true;
            StartCoroutine(WorkTime());
        }
    }

    IEnumerator WorkTime()
    {
        yield return new WaitForSeconds(60f);
        inventory.playerMoney += income;
        inventory.totalMoney += income;
        working = false;
        Debug.Log("Worker has payed player");
    }
}
