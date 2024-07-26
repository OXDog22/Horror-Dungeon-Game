using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speed = 1;
    private Rigidbody enemyRb;
    private GameObject player;
    public float enemySensingDistance = 5;
    public float enemyPounceRange = 2;
    private Animator enemyAnimator;
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
        
          //Chases the player if it is too close
        if (Mathf.Abs(playerDirection.x) < enemySensingDistance && Mathf.Abs(playerDirection.z) < enemySensingDistance && !enemyAnimator.GetBool("Pounce")) 
        {
            
            if (Mathf.Abs(playerDirection.x) < enemyPounceRange && Mathf.Abs(playerDirection.z) < enemyPounceRange)
            {
                enemyAnimator.SetBool("Pounce", true);
            } else
            {
                enemyAnimator.SetBool("isChasing", true);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerDirection.normalized * -1), Time.deltaTime * 5);
                transform.Translate(playerDirection.normalized * speed * Time.deltaTime);
                
            }

        } else
        {
            enemyAnimator.SetBool("isChasing", false);
            
            if (enemyAnimator.GetBool("Pounce"))
            {
                transform.Translate(playerDirection.normalized * speed * Time.deltaTime);
            }
        }



        //unused code
        //transform.Translate(new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z).normalized * speed * Time.deltaTime);
        //Quaternion facePlayer = Quaternion.Euler(playerDirection.x, playerDirection.y, playerDirection.z);
        //transform.rotation = facePlayer;
    }

    void DisableMovement()

    {
        speed = 0;
    }
}