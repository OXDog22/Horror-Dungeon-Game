using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerScript : MonoBehaviour
{
    private float MinYaw = -360;
    private float MaxYaw = 360;
    private float MinPitch = -10;
    private float MaxPitch = 10;
    public float LookSensitivity = 10;
    private float cameraHeight = 1;
    private GameObject playerCamera;
    private bool hiding = false;
    private int keys = 0;
    public GameObject [] playerInv;

    protected float yaw;
    protected float pitch;

    private Rigidbody playerRb;
    public float speed = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * forwardInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        //playerRb.AddForce(Vector3.forward * speed * forwardInput * Time.deltaTime);

        // Camera Look
        yaw += Input.GetAxisRaw("Mouse X") * LookSensitivity;
        pitch -= Input.GetAxisRaw("Mouse Y") * LookSensitivity;

        yaw = ClampAngle(yaw, MinYaw, MaxYaw);
        pitch = ClampAngle(pitch, MinPitch, MaxPitch);

        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        playerCamera.transform.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y + cameraHeight, playerRb.transform.position.z);
        playerRb.transform.rotation = playerCamera.transform.rotation;
        Debug.Log(hiding);
        Debug.Log(keys);

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
        if (other.CompareTag("HidingSpot"))
        {
            hiding = true;
        }
        if (other.CompareTag("KeyItem"))
        {
            keys += 1;
            //Destroy(other);
        }
        if (other.CompareTag("LockedDoor"))
        {
            if (keys > 0)
            {
                keys -= 1;
                //Destroy(other);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hiding = false;
    }
}