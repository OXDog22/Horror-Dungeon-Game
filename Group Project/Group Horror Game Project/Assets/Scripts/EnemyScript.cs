using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speed = 2;
    private Rigidbody enemyRb;
    private GameObject player;
    public float enemySensingDistance = 5;
    public float enemyChaseRange = 10;
    public float enemyPounceRange = 2;
    private Animator enemyAnimator;
    private int movementEnabled = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Cylinder");
        enemyAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 playerDirection = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
        
          //Chases the player if it is too close or exceeds the chase range and is not already pouncing/ has pounced
        if ((Mathf.Abs(playerDirection.x) < enemySensingDistance && Mathf.Abs(playerDirection.z) < enemySensingDistance || (enemyAnimator.GetBool("isChasing") && Mathf.Abs(playerDirection.x) < enemyChaseRange && Mathf.Abs(playerDirection.z) < enemyChaseRange ) && !enemyAnimator.GetBool("Pounce")))
        {
            
            if (Mathf.Abs(playerDirection.x) < enemyPounceRange && Mathf.Abs(playerDirection.z) < enemyPounceRange)
            {
                enemyAnimator.SetBool("Pounce", true);
            } else
            {
                enemyAnimator.SetBool("isChasing", true);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerDirection.normalized * -1), Time.deltaTime * 5 * movementEnabled);
                transform.Translate(playerDirection.normalized * speed * Time.deltaTime * movementEnabled);
                
            }

        } else
        {
            enemyAnimator.SetBool("isChasing", false);
            
            if (enemyAnimator.GetBool("Pounce"))
            {
                transform.Translate(playerDirection.normalized * speed * Time.deltaTime * movementEnabled);
            }
        }



        //unused code
        //transform.Translate(new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z).normalized * speed * Time.deltaTime);
        //Quaternion facePlayer = Quaternion.Euler(playerDirection.x, playerDirection.y, playerDirection.z);
        //transform.rotation = facePlayer;
    }

    //called by the "walk to pounce" clip
    void DisableMovement()

    {
        movementEnabled = 0;
    // for the sake of types, 0 = false, 1 = true
    }
}