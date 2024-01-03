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
    // Start is called before the first frame update
    void Start()
    {
        canSell = true;
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // if player clicks button at shop...
        if ((player.position - transform.position).magnitude < .4f && canSell)
        {
            //audio.Play();
         //   Debug.Log("Player is near");
           // inventory.SellFish();
            //canSell = false;

            if(inventory.fish[0] != null) // if inventroy is not already empty
            {
                audio.Play();
                inventory.SellFish();
                canSell = false;

            }
           // display.UpdateInventoryDisplay();
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
