using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerScript : MonoBehaviour
{
    public GameObject[] CandlePhases;
    private float MinYaw = -360;
    private float MaxYaw = 360;
    private float MinPitch = -10;
    private float MaxPitch = 10;
    public float LookSensitivity = 10;
    private float cameraHeight = 1;
    private GameObject playerCamera;
    public bool hiding = false;
    public int keys = 0;
    public GameObject [] playerInv;
    private GameObject lever1;
    private GameObject lever2;
    private GameObject lever3;
    private GameObject lever4;
    private GameObject lever5;
    private GameObject dungeonkey;
    private GameObject dungeondoor;
    public int Hp;
    public AudioClip stepping;
    private AudioSource playerAudio;
    public bool stopper = false;
    public int i = 0;

    protected float yaw;
    protected float pitch;

    private Rigidbody playerRb;
    private GameManager gameManager;
    public float speed = 5.0f;
    private bool button1 = true;
    private bool button2 = false;
    private bool button3 = false;
    private bool button4 = false;
    private bool button5 = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        playerCamera = GameObject.Find("Main Camera");
        lever1 = GameObject.Find("Lever1");
        lever2 = GameObject.Find("Lever2");
        lever3 = GameObject.Find("Lever3");
        lever4 = GameObject.Find("Lever4");
        lever5 = GameObject.Find("Lever5");
        dungeonkey = GameObject.Find("Key");
        dungeondoor = GameObject.Find("Door");
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //This if condition disables movement and sound when the game is over
        if (gameManager.gameActive)
        {
            float forwardInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * speed * forwardInput * Time.deltaTime);
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        } else
        {
            stopper = true;
        }
        
        //playerRb.AddForce(Vector3.forward * speed * forwardInput * Time.deltaTime);

        // Camera Look

        
        yaw += Input.GetAxisRaw("Mouse X") * LookSensitivity;
        pitch -= Input.GetAxisRaw("Mouse Y") * LookSensitivity;

        yaw = ClampAngle(yaw, MinYaw, MaxYaw);
        pitch = ClampAngle(pitch, MinPitch, MaxPitch);

        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        playerCamera.transform.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y + cameraHeight, playerRb.transform.position.z);
        playerRb.transform.rotation = playerCamera.transform.rotation;

        //dungeon puzzle solution
        if (button1 == false)
        {
            if (button2 == true)
            {
                if (button3 == true)
                {
                    if (button4 == false)
                    {
                        if (button5 == true)
                        {
                            dungeonkey.transform.Translate(new Vector3(0, -5, 0));
                        }
                    }
                }
            }
        }

        //crouch
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            speed = 2.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(1, 1, 1);
            speed = 5.0f;
        }

        //Update Candle states by HP
        CandleUpdate();

        //walking sound
        if (Input.GetKeyDown(KeyCode.W) && gameManager.gameActive)
        {
            stopper = false;
            StartCoroutine(WalkingTimer());
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            stopper = true;
        }
    }

    IEnumerator WalkingTimer()
    {
        for (i = 0; i < 10000000; i++)
        {
            if (stopper == false)
            {
                yield return new WaitForSeconds(0.6f);
                playerAudio.PlayOneShot(stepping, 0.2f);
            }
        }
    }

    protected float ClampAngle(float angle)
    {
        return ClampAngle(angle, 0, 360);
    }

    protected float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }

    private void OnTriggerEnter(Collider other)
    {
        //for hiding spot, picking up key
        if (other.CompareTag("HidingSpot"))
        {
            hiding = true;
        }
        if (other.CompareTag("Key"))
        {
            keys += 1;
            Destroy(other);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LockedDoor"))
        {
            if (keys > 0)
            {
                keys -= 1;
                Destroy(dungeondoor);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //for levers in dungeon
        if (other.CompareTag("button1"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (button1 == true)
                {
                    button1 = false;
                    lever1.transform.Translate(new Vector3(0, -0.5f, 0));
                }
                else if (button1 == false)
                {
                    button1 = true;
                    lever1.transform.Translate(new Vector3(0, 0.5f, 0));
                }
            }
        }
        if (other.CompareTag("button2"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (button2 == true)
                {
                    button2 = false;
                    lever2.transform.Translate(new Vector3(0, -0.5f, 0));
                }
                else if (button2 == false)
                {
                    button2 = true;
                    lever2.transform.Translate(new Vector3(0, 0.5f, 0));
                }
            }
        }
        if (other.CompareTag("button3"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (button3 == true)
                {
                    button3 = false;
                    lever3.transform.Translate(new Vector3(0, -0.5f, 0));
                }
                else if (button3 == false)
                {
                    button3 = true;
                    lever3.transform.Translate(new Vector3(0, 0.5f, 0));
                }
            }
        }
        if (other.CompareTag("button4"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (button4 == true)
                {
                    button4 = false;
                    lever4.transform.Translate(new Vector3(0, -0.5f, 0));
                }
                else if (button4 == false)
                {
                    button4 = true;
                    lever4.transform.Translate(new Vector3(0, 0.5f, 0));
                }
            }
        }
        if (other.CompareTag("button5"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (button5 == true)
                {
                    button5 = false;
                    lever5.transform.Translate(new Vector3(0, -0.5f, 0));
                }
                else if (button5 == false)
                {
                    Debug.Log("y");
                    button5 = true;
                    lever5.transform.Translate(new Vector3(0, 0.5f, 0));
                }
            }
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        hiding = false;
    }

    private void CandleUpdate()
    {
        if (Hp == 3)
        {
            CandlePhases[0].SetActive(true);
            CandlePhases[1].SetActive(false);
            CandlePhases[2].SetActive(false);
            CandlePhases[3].SetActive(false);

        }
        else if (Hp == 2)
        {
            CandlePhases[0].SetActive(false);
            CandlePhases[1].SetActive(true);
            CandlePhases[2].SetActive(false);
            CandlePhases[3].SetActive(false);

        }
        else if (Hp == 1)
        {
            CandlePhases[0].SetActive(false);
            CandlePhases[1].SetActive(false);
            CandlePhases[2].SetActive(true);
            CandlePhases[3].SetActive(false);

        }
        else if (Hp == 0)
        {
            CandlePhases[0].SetActive(false);
            CandlePhases[1].SetActive(false);
            CandlePhases[2].SetActive(false);
            CandlePhases[3].SetActive(true);

        }

    }
}