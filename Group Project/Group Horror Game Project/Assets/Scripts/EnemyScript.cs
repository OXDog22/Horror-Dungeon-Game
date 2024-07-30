using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private float speed = 2;
    private Rigidbody enemyRb;
    private GameObject player;
    private PlayerScript PlayerScript;
    public float enemySensingDistance = 5;
    public float enemyChaseRange = 10;
    public float enemyPounceRange = 2;
    private Animator enemyAnimator;
    private int movementEnabled = 1;
    private bool hiding;
    public GameObject animatedBlood;
    private bool hitCoolDown = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
<<<<<<< HEAD
=======
        PlayerScript= player.GetComponent<PlayerScript>();
>>>>>>> b80e774e95dea424ef7036a815a888a5159fc57c
        enemyAnimator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 playerDirection = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
        
        hiding = PlayerScript.hiding;

          //Chases the player if it is too close or exceeds the chase range and is not already pouncing/ has pounced
        if ((Mathf.Abs(playerDirection.x) < enemySensingDistance && Mathf.Abs(playerDirection.z) < enemySensingDistance || (enemyAnimator.GetBool("isChasing") && Mathf.Abs(playerDirection.x) < enemyChaseRange && Mathf.Abs(playerDirection.z) < enemyChaseRange ) && !enemyAnimator.GetBool("Pounce")) && !hiding)
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



    private void OnTriggerEnter(Collider other)
    {

        //player takes damage
        if (other.CompareTag("Player") && !hiding && !hitCoolDown)
        {
            PlayerScript.Hp -= 1;

            animatedBlood.SetActive(true);
            hitCoolDown= true;
            StartCoroutine(HurtEffects());
         
        }

        
    }

    IEnumerator HurtEffects()
    {
        yield return new WaitForSeconds(3);
        animatedBlood.SetActive(false);
        hitCoolDown = false;

    }

    
}