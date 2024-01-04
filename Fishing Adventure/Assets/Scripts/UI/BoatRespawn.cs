using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRespawn : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public Transform boat;
    public PlayerInventory inventory;
    public GameObject info;
    private bool canTow = true;
    Vector3 boatLocation;

    public void Start()
    {
        info.SetActive(false);
    }

    public void Update()
    {
        if ((player.position - transform.position).magnitude < .3f && inventory.playerMoney >= 45f)
        {
            info.SetActive(true);
            if (Input.GetKeyDown("z") && canTow)
            {
                canTow = false;
                boatLocation = new Vector3(-4.146f, -0.029f, 0f);
                boat.position = boatLocation;
                inventory.playerMoney -= 45f; 
                StartCoroutine(BoatCoolDown());
            }
        }
        else
        {
            info.SetActive(false);
        }
    }

    IEnumerator BoatCoolDown()
    {
        yield return new WaitForSeconds(1f);
        canTow = true;
    }




}
