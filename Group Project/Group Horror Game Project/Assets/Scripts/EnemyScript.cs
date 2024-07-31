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
    private GameManager GameManager;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        PlayerScript= player.GetComponent<PlayerScript>();
        enemyAnimator = gameObject.GetComponent<Animator>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        origin = gameObject.transform.position;
        
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
                transform.Translate(playerDirection.normalized * speed * Time.deltaTime * movementEnabled * -1);
                
            }

        } else
        {
            enemyAnimator.SetBool("isChasing", false);
            
            if (enemyAnimator.GetBool("Pounce"))
            {
                transform.Translate(playerDirection.normalized * speed * Time.deltaTime * movementEnabled * -1);
            } else
            {
                Vector3 originDirection = new Vector3(origin.x - transform.position.x, 0, origin.z - transform.position.z);

                if (Mathf.Abs(originDirection.z) > 1 || (Mathf.Abs(originDirection.x) > 1))
                {
                    //return to origin
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(originDirection.normalized * -1), Time.deltaTime * 5 * movementEnabled);
                    transform.Translate(originDirection.normalized * speed * Time.deltaTime * movementEnabled * -1);
                }
                

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

    //called at start of stand up clip
    void StandUp()
    {
        enemyAnimator.SetBool("Pounce", false);
        movementEnabled = 1; 
    }



    private void OnTriggerEnter(Collider other)
    {

        //player takes damage
        if (other.CompareTag("Player") && !hiding && !hitCoolDown)
        {
            PlayerScript.Hp -= 1;
            if (PlayerScript.Hp < 1)
            {
                GameManager.gameActive = false;
            }

            if (PlayerScript.Hp > 0)
            {
                animatedBlood.SetActive(true);
                hitCoolDown = true;
                StartCoroutine(HurtEffects());

            }
            
         
        }

        
    }

    IEnumerator HurtEffects()
    {
        yield return new WaitForSeconds(3);
        animatedBlood.SetActive(false);
        hitCoolDown = false;

    }

    
}