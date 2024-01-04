using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public GameObject dock;
    public PlayerInventory inventory;
    public InventoryDisplay display;
    public bool canSell;
    private new AudioSource audio;
    private bool finishedUpgrade = false;

    void Start()
    {
        canSell = true;
        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if ((player.position - transform.position).magnitude < .4f && canSell)
        {
            if(inventory.fish[0] != null) // if inventroy is not already empty
            {
                audio.Play();
                inventory.SellFish();
                canSell = false;

            }
            StartCoroutine(RefreshSells());
        }

        if (inventory.dockUpgraded == true && finishedUpgrade == false)
        {
            UpdateDock();
            finishedUpgrade = true;
        }       
    }

    public void UpdateDock()
    {
        dock.SetActive(true);
    }


    IEnumerator RefreshSells()
    {
        yield return new WaitForSeconds(3f);
        canSell = true;
    }
}
