using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float MinYaw = -360;
    public float MaxYaw = 360;
    public float MinPitch = -10;
    public float MaxPitch = 10;
    public float LookSensitivity = 1;
    public float cameraHeight = 3;
    private GameObject playerCamera;

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


}

