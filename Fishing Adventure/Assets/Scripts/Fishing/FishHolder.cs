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
    public LayerMask waterLayer; // layer used to fish
    public float maxFish = 5f;
    public bool fishOn = false;
    public bool canFish = true;
    public bool stopFishing; // if true then stop fishing
    public bool fishComplete = false; // if player is done fishing
    //public ScriptableObject fishTest;

    public PlayerInventory inventory;
   // public FishInstance fishInstance;
    public RandomFish rndFish;
    public NPC npc;
    public Transform dockDistance;
    [SerializeField] private new AudioSource audio; // FIXX: weird glitch! Plays wrong audio for some reason
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

    //   MyData.PlayerMoney = inventory.playerMoney; // TEST
    
    }

    void Update()
    {
        if (inventory.inventoryFull == false && hidden == false) // If inventory is not full
        {
            fullInventory.SetActive(false);
            hidden = true;
            full = false;
            Debug.Log("FALSE");
        }

       if (inventory.inventoryFull == true && full == false) // If inventory is full
        {
            fullInventory.SetActive(true);
            hidden = false;
            full = true;
            Debug.Log("TRUE");

        }
     //   SaveGameManager.CurrentSaveData.PlayerData = MyData;
        FinishedFishing(); // checks if player has caught fish or fish excaped

        if (player.playerFishing == false) // if player is not fishing
        {
            fishGame.SetActive(false); // deactivate fishing bar
        }

   
        if (anim.GetBool("isFishing") == true && canFish) // if player has casted their line
        {
            stopFishing = false;
            StartCoroutine(StartFishing());
        }

        if (anim.GetBool("isFishing") == false) // if fishing animation boolean is false
        {
            stopFishing = true;
            fishHit.SetActive(false); // deactivate fishing bar

        }


        if (fishBar.fishCaught == true) // If player caught a fish
        {
        //    anim.SetTrigger("Reeling"); // start reeling animation
            fishBar.fishCaught = false;
            fishDisplay.SetActive(true);
            audio.Play();
            
            //anim.SetTrigger("Reeling"); // start reeling animation
            //anim.ResetTrigger("Reeling");
            inventory.AddFish(); //Add fish to inventory
            fishInfo.ShowFish(); //Display info about caught fish

            // Add fish to fish journal
            
            
            
            if (npc.ActiveQuest == true)
            {
                npc.FishCounter += 1;
                inventory.CountFish += 1;
                npc.updateQuest = true;
            }


        }
        // anim.ResetTrigger("Reeling");
        
    }

    public void FinishedFishing()
    {
        if (fishComplete == true)
        {
            fishGame.SetActive(false); // deactivate fishing bar
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

        //if (fishBar.currentlyFishing != true) // if not already fishing
        if (canFish == true)
        {
            canFish = false; // prevent fishing multiple times at same time
            float randomBite = Random.Range(2, 5); // fish will take 2-5 seconds to bite
            yield return new WaitForSeconds(randomBite); // test
            fishHit.SetActive(true); // fish on the line
            yield return new WaitForSeconds(1f);
            //canFish = true;

            if (stopFishing == false) 
            {
                SearchForFish(); // Start fishing game
            }
        }
    }

  //  public bool SearchForFish()
    public void SearchForFish()
    {
        float randomNumber = Random.Range(0, 100);

            if (randomNumber >= 75 && inventory.SpikedHook != true) // 25% fish took the bait and left. Can be prevented with Spiked Hook upgrade
            {
                Debug.Log("Fish took your bait!");
                fishOn = false; // fish no longer on the line
                //anim.ResetTrigger("Reeling"); // reset reel animation
                anim.SetBool("fishOn", false); // set fishOn to false
                fishHit.SetActive(false); // remove exclamation mark
                canFish = true; // allow player to fish again
                baitTaken.SetActive(true);
                StartCoroutine(FishTookBait());


               // return false;
            }

            else // fish is on the line
            {
                Debug.Log("Fish on the line");
                fishOn = true; // fish is on the line
                anim.SetTrigger("Reeling"); // start reeling animation
                anim.SetBool("fishOn", true); // set fishOn to true
                fishGame.SetActive(true); // activate fishing 
                

            /// TEST ///
                if ((transform.position - dockDistance.position).magnitude > 5f && (transform.position - dockDistance.position).magnitude <= 14f)  // Fishing in water that is slightly deep
                {
                    Debug.Log("Average Water");
                    if (inventory.hookDepth > 25f) // max fishing depth for this water is 25f "75 feet"
                    {
                        depthText.text = "Water Depth: " + "25m";
                        rndFish.FindRandomFish(25f); // set to max allowed fishing depth
                    }
                    
                    else // hook depth is less than or equal to 25f
                    {
                        depthText.text = "Water Depth: " + "25m";
                        rndFish.FindRandomFish(inventory.hookDepth);
                    }
                }

                else if ((transform.position - dockDistance.position).magnitude > 14f && (transform.position - dockDistance.position).magnitude < 24f) // Fishing in deep water
                {
                    Debug.Log("Deep Water");
                    if (inventory.hookDepth > 60f) // max fishing depth for this water is 60f "180 feet"
                    {
                        depthText.text = "Water Depth: " + "60m";
                        rndFish.FindRandomFish(60f); // set to max allowed fishing depth
                    }
                    else
                    {
                        depthText.text = "Water Depth: " + "60m";
                        rndFish.FindRandomFish(inventory.hookDepth); // max fishing depth is less than or equal to 55f
                    }
                }

                else if ((transform.position - dockDistance.position).magnitude >= 24f)  // Fishing in deepest water
                {
                    Debug.Log("Very Deep Water");
                    depthText.text = "Water Depth: " + "100m";
                    rndFish.FindRandomFish(inventory.hookDepth); // max fishing depth is whatever your hook depth is
                }

                else // Fishing in shallow water 
                {
                    Debug.Log("Shallow Water");
                    if (inventory.hookDepth > 10f) // max fishing depth is 10f in shallow water
                    {
                        depthText.text = "Water Depth: " + "10m";
                        rndFish.FindRandomFish(10f); // set to max allowed fishing depth
                    }
                    else // hook depth is less than or equal to 10f
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
