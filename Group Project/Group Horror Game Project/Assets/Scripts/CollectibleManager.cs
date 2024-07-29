using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class CollectibleManager : MonoBehaviour
{
    public float rotationRate = 1.0f;
    private GameObject [] playerInventory;
    private float OscolateBy;
    
    // Start is called before the first frame update
    void Start()
    {
        //place the keys by their locations as defined in an array that is loaded by the scene or manually placed . managed by gameManager
    }

    // Update is called once per frame
    void Update()
    {
        //playerInventory = GameObject.Find("PlayerScript").playerInv; Obtains a reference to playerInv

        // Ocscolate up and down, rotate along the Y-axis, and look irrestible  ONLY IF KEY
        if (gameObject.CompareTag("Key"))
        {
            //transform.rotation += transform.forward;
            OscolateBy = Mathf.Sin(Time.time);

            transform.position = new Vector3(0, OscolateBy/2 + 1, 0);
            //not configured yet
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Player"));
        //The player object is currently untagged
       // {
       //     if (gameObject.CompareTag("Journal_Entry"))
       //     { 
                //Pop up in front of player's face
       //     }

            //playerInventory[playerInventory.Length + 1] = collision.gameObject;
       //     Destroy(gameObject);
        //}
    }
}
