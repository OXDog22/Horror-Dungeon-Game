using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.Android;

public class CollectibleManager : MonoBehaviour
{
    public float rotationRate = 1.0f;
    //private GameObject [] playerInventory;
    private float OscolateBy;
    private float yOffset;
    //private PlayerScript playerScript; 
    
    // Start is called before the first frame update
    void Start()
    {
        //place the keys by their locations as defined in an array that is loaded by the scene or manually placed . managed by gameManager
        //playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        yOffset = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        //playerInventory = playerScript.playerInv; //use player inventory in the player script

        // Ocscolate up and down, rotate along the Y-axis, and look irrestible  ONLY IF KEY
        if (gameObject.CompareTag("Key"))
        {
            //transform.rotation += transform.forward;
            OscolateBy = Mathf.Sin(Time.time);

            //transform.position = new Vector3(transform.position.x, OscolateBy/2 + 1 + yOffset, transform.position.z);
            //not configured yet
        }

    }

  //void OnCollisionEnter(Collision collision)     Inventory manager will manage this
   // {
    //    if (collision.gameObject.CompareTag("Player"));
        //The player object is currently untagged
   //    {
    //        if (gameObject.CompareTag("Journal_Entry"))
    //        { 
     //           //Pop up in front of player's face
     //       }

     //       playerInventory[playerInventory.Length + 1] = collision.gameObject;
    //        Destroy(gameObject);
    //    }
    //}
}
