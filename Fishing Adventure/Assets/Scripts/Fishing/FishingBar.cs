using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBar : MonoBehaviour
{
    [SerializeField] private Transform topPosition; // top pivot for fishing bar
    [SerializeField] private Transform bottomPosition; // bottom pivot of fishing bar

    [SerializeField] private Transform fish; // fish icon 

    [SerializeField] private float timeMultiply; // seconds it takes for fish to move again
    [SerializeField] private float smoothMotion; // smooth time

    [SerializeField] private Transform hook; // hook
    [SerializeField] public float hookSize; // size of the hook area. Larger area increases chance of catching
    public float hookStrength; // strength of the hook. Higher the strength the earier it is to catch fish

    [SerializeField] public float hookPullPower;  // Speed at which hook rises up
    [SerializeField] public float gravityPull; // gravity of the hook
    [SerializeField] public float progressDropRate; // rate at which progress bar deteriates

    [SerializeField] private float failTimer; // timer

    [SerializeField] private SpriteRenderer hookSprite;

    [SerializeField] private Transform progressBarContainer;


    private float hookPosition;
    private float hookProgress;
    private float hookPullVelocity; // Current speed of hook in fishing area

    private float fishPosition;
    private float fishTowards;
    private float fishSpeed;

    private float timer;
    private float holdTimer;

    public bool pause = false;
    public bool fishCaught = false;
    public bool currentlyFishing = false;
    private bool reelingSound = false;

   public FishHolder fishManager;
   public PlayerInventory inventoryStats;
   private new AudioSource audio;
   //private GameObject excapedText;


    private void Start()
    {

      //  anim = GetComponent<Animator>();
        holdTimer = failTimer;
        audio = GetComponent<AudioSource>();
        ChangeSize();
        //currentlyFishing = true;
    }
    
    private void ChangeSize()
    {
        Bounds bound = hookSprite.bounds;
        float ySize = bound.size.y;
        Vector3 scale = hook.localScale;
        float distance = Vector3.Distance(topPosition.position, bottomPosition.position);
        scale.y = (distance / ySize * hookSize);
        hook.localScale = scale;
    }

    private void PlaySound()
    {
        if (currentlyFishing && reelingSound == false)
        {
            reelingSound = true;
            // Play reeling sound
            audio.Play();
             
        }
    }
   
    
    private void Update()
    {
        GetFishInfo();
        Fishing();
        Hook();
        ProgressCheck();

        if (currentlyFishing)
        {
            fishManager.fishComplete = false;

            //pause = false;
        }
        
        hookStrength = inventoryStats.HookStrength;

       // inventoryStats.GetFishInfo(); // TEST 
       //GetFishInfo(); // TEST
       PlaySound();
        
                
    }

    public void Fishing()
    {
        timer -= Time.deltaTime; // reduce time
        currentlyFishing = true; // currently fishing

        if (timer < 0f) // if timer is still running
        {
            timer = UnityEngine.Random.value * timeMultiply;

            fishTowards = UnityEngine.Random.value; // get random area to move to
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishTowards, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPosition.position, topPosition.position, fishPosition);  // move fish randomly on the bar

    }


    public void ProgressCheck()
    {
        Vector3 scale = progressBarContainer.localScale;
        scale.y = hookProgress;
        progressBarContainer.localScale = scale;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishPosition && fishPosition < max)
        {
            hookProgress += hookStrength * Time.deltaTime; // Increase progress 
        }

        else
        {
            hookProgress -= progressDropRate * Time.deltaTime; // Decrease progress
            failTimer -= Time.deltaTime; // decrease failTimer

            if (failTimer <= 0f) // if bar is empty after timer then fish excaped
            {
                FishExcaped();
            }
        }

        if (hookProgress >= 1f) // if bar is full then fish is caught
        {
            FishCaught();
            Success();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f); // clamp progress from 0 to 1
    }


    void Hook()
    {
        // ADD: if holding phone screen button down...
        if (Input.GetMouseButton(0)) // tap left click to move hook
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        } 
        hookPullVelocity -= gravityPull * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if (hookPosition - hookSize / 2 <= 0f && hookPullVelocity < 0f)
        {
            hookPullVelocity = 0f;
        }

        if (hookPosition + hookSize / 2 >= 1f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottomPosition.position, topPosition.position, hookPosition);

    }

    public void GetFishInfo() // Increase challenge of catching fish based on rariety 
    {
        if (inventoryStats.displayFish[0].Rariety == "Common") 
        {
            // +0% harder to catch
            progressDropRate = 0.1f;
            timeMultiply = 7f; // 7 seconds
            //failTimer = 8f;
        }
        else if (inventoryStats.displayFish[0].Rariety == "Uncommon")
        {
            // +15% harder to catch
           // progressDropRate = 0.11f;
            progressDropRate = 0.115f;
            timeMultiply = 6f; // 6 seconds
            //failTimer = 8f;
        }
        else if (inventoryStats.displayFish[0].Rariety == "Rare")
        {
            // +25% harder to catch
            progressDropRate = 0.125f;
            timeMultiply = 5f; // 5 seconds
            //failTimer = 8f;
        }
        else if (inventoryStats.displayFish[0].Rariety == "Epic")
        {
            // +60% harder to catch
            //progressDropRate = 0.15f;
            progressDropRate = 0.16f;
            timeMultiply = 4f; // 4 seconds
            //failTimer = 8f;
        }
        else if (inventoryStats.displayFish[0].Rariety == "Legendary")
        {
            // +100% harder to catch
            //progressDropRate = 0.17f;
            progressDropRate = 0.2f;
            timeMultiply = 3f; // 3 seconds
            //failTimer = 8f;
            
        }
        /*
        else
        {
            Debug.Log("Error");
            return;
        }
        */

    }


   
    public void FishCaught() // Fish has been caught
    {
        pause = true; // pause fishing bar
        Debug.Log("FISH CAUGHT");
        fishCaught = true; // fish has been caught
        currentlyFishing = false; // stop fishing
        fishManager.fishComplete = true;
        hookProgress = 0f; // reset progress
        failTimer = holdTimer; // reset timer
        audio.Stop();
        reelingSound = false;

    }

    public void FishExcaped() // Fish has excaped. // FIX: Not hiding fishing bar in build play!! 
    {
        pause = true;
        Debug.Log("FISH EXCAPED");
        currentlyFishing = false;
        inventoryStats.totalExcapes += 1; // add to excape inventory stat
       // fishManager.stopFishing = true;
        fishManager.fishComplete = true;
        hookProgress = 0f;
        failTimer = holdTimer;
        audio.Stop();
        reelingSound = false;
       // gameObject.SetActive(false);
       // StartCoroutine(FishAgain());
    }

    public bool Success()
    {
        return true;
    }

    
    /*
    IEnumerator DecreaseTime()
    {
        yield return new WaitForSecounds(1f);
        failTimer -= 1f;

    }
    */


} 
