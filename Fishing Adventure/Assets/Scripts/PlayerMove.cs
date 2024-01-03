using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float maxspeed;
    [SerializeField] private Transform respawnPoint;
    //public float jumpforce = 1;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Vector3 distance;
    [SerializeField] private new AudioSource audio;
    public Boat boat;
    //private bool canMove = true;
   [SerializeField] public GameObject inventoryUI;
   public PlayerInventory inventory;
   [SerializeField] public GameObject statsUI;
   [SerializeField] private Transform border;
   [SerializeField] private GameObject quitButton;
  
    [HideInInspector]
    public bool lookingRight = true;
    public FishHolder manageFish;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded = false;
    public bool playerFishing;
    private bool show = false;
    Vector3 boatOffset;
    private bool changePos = true;
    private bool showStats = false;
    private float speedHolder = 0f;
    public bool gamePaused = false;


    public Transform dockDistance; // Delete after testing!
   

    void Start() 
    {
      rb = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
      audio = GetComponent<AudioSource>();
      distance = new Vector3(0, .25f, 0);
      playerFishing = false;
      inventoryUI.SetActive(false);
      statsUI.SetActive(false);
      speedHolder = maxspeed;
    }


    void Update()
    {

    /*
      if (Input.GetKeyDown(KeyCode.N)) // DELETE later!
      {
        inventory.playerMoney += 1000f;
      }
    */
      PlayerFishing();
      ShowInventory();
      ShowStats(); // used FixedUpdate() ??
      DriveBoat();

      PauseGame();
    }

    public void DriveBoat() 
    {
      if (boat.Driving)
      {
        anim.SetTrigger("Rowing");
        anim.SetBool("onBoat", true);

        if (inventory.BoatUpgrade == true) // if player has upgraded boat
        {
          maxspeed = 2.25f; // increase player speed on boat
          speedHolder = maxspeed;
        }

        if (changePos) // Move character position to inside of the boat
        {
          boatOffset = new Vector3(0f,-.21f,0f);
          transform.position += boatOffset;
          changePos = false;
        }
        
      }
      else if (boat.Driving == false)
      {
        anim.ResetTrigger("Rowing");
        anim.SetBool("onBoat", false);
        changePos = true;
        maxspeed = 1.5f; // reset player speed
        speedHolder = maxspeed;
      }

    }


    void FixedUpdate()
    {
      RespawnAtDock();
      /*
       if (boat.Driving)
      {
        anim.SetTrigger("Rowing");
        anim.SetBool("onBoat", true);

        if (changePos)
        {
          boatOffset = new Vector3(0f,-.21f,0f);
          transform.position += boatOffset;
          changePos = false;
        }

        //rb.constraints = RigidbodyConstraints.FreezePosition;
       // rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        //this.GetComponent<Rigidbody2D>().useGravity = false; 

        // Move character position to inside if the boat
      }
      else if (boat.Driving == false)
      {
        anim.ResetTrigger("Rowing");
        anim.SetBool("onBoat", false);
        changePos = true;
       // rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        //rb.constraints = RigidbodyConstraints2D.None;
       // this.GetComponent<Rigidbody2D>().useGravity = true; 

        // Move character position to on top of the boat
      }
      */

        float hor = Input.GetAxis("Horizontal");
        float moveInput = Input.GetAxisRaw("Horizontal");

      //  anim.SetFloat ("Speed", Mathf.Abs (hor));

        //PlayerFishing();
        rb.velocity = new Vector2(hor * maxspeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);

        if (moveInput != 0) // if moving stop all fishing
        {
            anim.SetTrigger("Walking");
            anim.SetBool("isFishing", false);
            anim.ResetTrigger("Fishing");
            anim.ResetTrigger("Reeling");
            anim.SetBool("fishOn", false);
            playerFishing = false;   
        }

        if (moveInput == 0) // if not moving
        {
            anim.ResetTrigger("Walking");
            //anim.SetTrigger("Idle");
        }


        if ((hor > 0 && !lookingRight) || (hor < 0 && lookingRight))
        {
          FlipAxis ();
        }
    //  }



    }

    public void FlipAxis()
    {
      lookingRight = !lookingRight;
      Vector3 myScale = transform.localScale;
      myScale.x *= -1;
      transform.localScale = myScale;
    }

    public void PlayerFishing() // fishing animation
    {
      if (Input.GetKeyDown("space") && playerFishing == false) // if not already fishing
      {
       // anim.ResetTrigger("Reeling");
        audio.Play(); // player fishing sound
        anim.SetTrigger("Fishing"); // fishing
        anim.SetBool("isFishing", true); // fishing is true
        playerFishing = true;
        manageFish.canFish = true;
       // manageFish.fishComplete = false;
        if (inventory.fish[inventory.maxFish - 1] != null) // check if invetory is full
          {
            Debug.Log("Inventory Is FULL");
            inventory.inventoryFull = true;
          }

       if (inventory.inventoryFull == true)  // Don't allow fishing if inventory is full
       {
          anim.SetBool("isFishing", false);
          anim.ResetTrigger("Fishing");
          anim.ResetTrigger("Reeling");
          anim.SetBool("fishOn", false);
          playerFishing = false;  
       }
      }

      else if (Input.GetKeyDown("space") && playerFishing == true) // stop fishing
      {
        anim.SetBool("isFishing", false);
        anim.ResetTrigger("Fishing");
        anim.ResetTrigger("Reeling");
        anim.SetBool("fishOn", false);
        playerFishing = false;   
      }
    }

  public void ShowInventory() // Display Inventory
  {
    if (Input.GetKeyDown("tab") && !show)
        {
            show = true;
            inventoryUI.SetActive(true);
           // inventoryUI.UpdateInventoryDisplay();
        }
        else if (Input.GetKeyDown("tab") && show)
        {
            show = false;
            inventoryUI.SetActive(false);
        }
  }

  public void ShowStats() // Display Player Stats
  {
    if (Input.GetKeyDown("left shift") && !showStats)
        {
            showStats = true;
            statsUI.SetActive(true);
           // inventoryUI.UpdateInventoryDisplay();
        }
        else if (Input.GetKeyDown("left shift") && showStats)
        {
            showStats = false;
            statsUI.SetActive(false);
        }
  }

  public void RespawnAtDock()
  {
    // if player falls in water spawn them back on the dock
    if (transform.position.y <= -1)
    {
      rb.gravityScale = 0; // stops player from glitching through ground because of downward velocity
      transform.position = respawnPoint.position; // spawn player back onto dock
      StartCoroutine(AddGravity());
    }

    // if player boat is lost at sea then allow them to pay to have it brought back to them
  }

  public void PauseGame()
  {
    if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown("escape")) && gamePaused == false) // Change to escape??
    {
      Time.timeScale = 0;
      gamePaused = true;
      // Allow player to quit game if they would like
      quitButton.SetActive(true);
      Debug.Log("Game Paused");
    }
/*
    if (Input.GetKeyDown(KeyCode.R) && gamePaused == true)
    {
      Time.timeScale = 1;
      gamePaused = false;
      quitButton.SetActive(false);
      Debug.Log("Game Resumed");
    }
*/

  }

  public void ResumeGame()
  {
    if (gamePaused == true)
    {
      Time.timeScale = 1;
      gamePaused = false;
      quitButton.SetActive(false);
      Debug.Log("Game Resumed");
    }
  }

  IEnumerator AddGravity() // Reapply gravity
  {
    yield return new WaitForSeconds(.15f);
    rb.gravityScale = 1;
  }


}
