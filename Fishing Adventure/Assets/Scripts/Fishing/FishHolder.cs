using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishHolder : MonoBehaviour
{
    [SerializeField] private GameObject fishHit;
    [SerializeField] private GameObject fishGame;
    [SerializeField] TextMeshProUGUI depthText;
    public FishingBar fishBar;
    public PlayerMove player;
    public FishDisplay fishInfo;
    public GameObject fishDisplay;
    private Animator anim;
    public LayerMask waterLayer; 
    public float maxFish = 5f;
    public bool fishOn = false;
    public bool canFish = true;
    public bool stopFishing; 
    public bool fishComplete = false; 

    public PlayerInventory inventory;
    public RandomFish rndFish;
    public NPC npc;
    public Transform dockDistance;
    [SerializeField] private new AudioSource audio;
    public GameObject fullInventory;
    private bool hidden = true;
    private bool full = false;
    public GameObject baitTaken;

    void Start()
    {
       anim = GetComponent<Animator>();
       audio = GetComponent<AudioSource>();
       stopFishing = false;
       fishGame.SetActive(false);   
    }

    void Update()
    {
        if (inventory.inventoryFull == false && hidden == false) 
        {
            fullInventory.SetActive(false);
            hidden = true;
            full = false;
        }

       if (inventory.inventoryFull == true && full == false) 
        {
            fullInventory.SetActive(true);
            hidden = false;
            full = true;
        }
        FinishedFishing(); 

        if (player.playerFishing == false) 
        {
            fishGame.SetActive(false); 
        }

   
        if (anim.GetBool("isFishing") == true && canFish) 
        {
            stopFishing = false;
            StartCoroutine(StartFishing());
        }

        if (anim.GetBool("isFishing") == false) 
        {
            stopFishing = true;
            fishHit.SetActive(false); 
        }


        if (fishBar.fishCaught == true) 
        {
            fishBar.fishCaught = false;
            fishDisplay.SetActive(true);
            audio.Play();
            inventory.AddFish(); 
            fishInfo.ShowFish(); 
            
            if (npc.ActiveQuest == true)
            {
                npc.FishCounter += 1;
                inventory.CountFish += 1;
                npc.updateQuest = true;
            }
        }    
    }

    public void FinishedFishing()
    {
        if (fishComplete == true)
        {
            fishGame.SetActive(false);
            anim.SetBool("isFishing", false);
            anim.ResetTrigger("Fishing");
            anim.ResetTrigger("Reeling");
            anim.SetBool("fishOn", false);
            canFish = true;
            player.playerFishing = false;
            fishComplete = false;
        }
    }


    IEnumerator StartFishing() 
    {
        if (canFish == true)
        {
            canFish = false; 
            float randomBite = Random.Range(2, 5); 
            yield return new WaitForSeconds(randomBite); 
            fishHit.SetActive(true); 
            yield return new WaitForSeconds(1f);

            if (stopFishing == false) 
            {
                SearchForFish(); 
            }
        }
    }

    public void SearchForFish()
    {
        float randomNumber = Random.Range(0, 100);

            if (randomNumber >= 75 && inventory.SpikedHook != true) // 25% fish took the bait and left. Can be prevented with Spiked Hook upgrade
            {
                fishOn = false; 
                anim.SetBool("fishOn", false); 
                fishHit.SetActive(false);
                canFish = true; 
                baitTaken.SetActive(true);
                StartCoroutine(FishTookBait());
            }

            else 
            {
                fishOn = true; 
                anim.SetTrigger("Reeling"); 
                anim.SetBool("fishOn", true); 
                fishGame.SetActive(true); 
                
                if ((transform.position - dockDistance.position).magnitude > 5f && (transform.position - dockDistance.position).magnitude <= 14f)  // Fishing in water that is slightly deep
                {
                    if (inventory.hookDepth > 25f) // max fishing depth for this water is 25m
                    {
                        depthText.text = "Water Depth: " + "25m";
                        rndFish.FindRandomFish(25f); 
                    }
                    
                    else 
                    {
                        depthText.text = "Water Depth: " + "25m";
                        rndFish.FindRandomFish(inventory.hookDepth);
                    }
                }

                else if ((transform.position - dockDistance.position).magnitude > 14f && (transform.position - dockDistance.position).magnitude < 24f) // Fishing in deep water
                {
                    if (inventory.hookDepth > 60f) // max fishing depth for this water is 60m
                    {
                        depthText.text = "Water Depth: " + "60m";
                        rndFish.FindRandomFish(60f); 
                    }
                    else
                    {
                        depthText.text = "Water Depth: " + "60m";
                        rndFish.FindRandomFish(inventory.hookDepth); 
                    }
                }

                else if ((transform.position - dockDistance.position).magnitude >= 24f)  // Fishing in deepest water
                {
                    depthText.text = "Water Depth: " + "100m";
                    rndFish.FindRandomFish(inventory.hookDepth); // max fishing depth is whatever your hook depth is
                }

                else // Fishing in shallow water 
                {
                    if (inventory.hookDepth > 10f) // max fishing depth is 10m
                    {
                        depthText.text = "Water Depth: " + "10m";
                        rndFish.FindRandomFish(10f); 
                    }
                    else 
                    {
                        depthText.text = "Water Depth: " + "10m";
                        rndFish.FindRandomFish(inventory.hookDepth); 
                    }
                }
            }
        }

        IEnumerator FishTookBait()
        {
            yield return new WaitForSeconds(0.5f);
            baitTaken.SetActive(false);
        } 
}
