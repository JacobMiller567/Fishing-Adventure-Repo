using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{

    [SerializeField] private float boatSpeed;
    [SerializeField] private Transform player;
    [SerializeField] private Transform dockDistance;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Transform border; 
    [SerializeField] private new AudioSource audio;
    private Rigidbody2D rb;
    public bool Driving = false;
    public bool canDrive = false;
    private bool upgraded = false;
    private bool playAudio = true;

    [HideInInspector]
    public bool lookingRight = true;
    Vector3 boatOffset;
    private float boatSpeedHolder = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        boatSpeedHolder = boatSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (inventory.BoatUpgrade == true && upgraded == false)
        {
            upgraded = true;
            boatSpeed = 2.25f;
        }
        */
        
        if ((player.position - transform.position).magnitude < .25f && Input.GetKeyDown("z") && !canDrive) // Drive boat
        {
            canDrive = true;
        }

        else if ((player.position - transform.position).magnitude < .25f && Input.GetKeyDown("z") && canDrive) // Stop boat
        {
            canDrive = false;
            rb.velocity = new Vector2(0, rb.velocity.y); // set speed to 0
            Driving = false;
            boatOffset = new Vector3(0f,.21f,0f);
            player.position += boatOffset;
            audio.Stop();
        }

        if (Driving == true && playAudio)
        {
            audio.Play();
            playAudio = false;
        }
        
        
    }

    void FixedUpdate()
    {
        if ((player.position - transform.position).magnitude < .25f && canDrive)
        {
            float hor = Input.GetAxis("Horizontal");
            float moveInput = Input.GetAxisRaw("Horizontal");
            if (inventory.BoatUpgrade == true && upgraded == false)
            {
                upgraded = true;
                boatSpeed = 2.25f;
                boatSpeedHolder = boatSpeed;
            }
        

            //  anim.SetFloat ("Speed", Mathf.Abs (hor));

            //PlayerFishing();
            rb.velocity = new Vector2(hor * boatSpeed, rb.velocity.y);
            Driving = true;

            //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);

            if (moveInput != 0) // if moving stop all fishing
            {
                Driving = true;
                //player.maxspeed = 2.25f;
                    //isDriving = true;
                //audio.Play();
                // Check if boat collided with dock...
                if ((border.position - transform.position).magnitude < 1f)
                {
                    Debug.Log("Near Border!!!");
                    boatSpeed = boatSpeed * -1;
                }
                else
                {
                    boatSpeed = boatSpeedHolder;
                }

            }

            if (moveInput == 0) // if not moving
            {
                //Driving = false;
                playAudio = true;
            }

            if ((hor > 0 && !lookingRight) || (hor < 0 && lookingRight))
            {
                FlipAxis ();
            }
        }

    }



     public void FlipAxis()
    {
      lookingRight = !lookingRight;
      Vector3 myScale = transform.localScale;
      myScale.x *= -1;
      transform.localScale = myScale;
    }


/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            boatSpeed = 0f;
        }
    }
*/


}
