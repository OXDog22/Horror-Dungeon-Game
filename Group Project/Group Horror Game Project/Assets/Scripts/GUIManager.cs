using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject playerCamera;
    public UnityEngine.UI.Button ArrowLeft;
    public UnityEngine.UI.Button ArrowRight;
    public GameObject Objectpt1;
    public GameObject Objectpt2;
    public GameObject Objectpt3;
    private UnityEngine.UI.Text TitleName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonTest()
    {
        print("We did it!");
    }
    public void MoveAround()
    {
        playerRb.transform.rotation = playerCamera.transform.rotation;
        Objectpt1.transform.rotation = playerCamera.transform.rotation;
        Objectpt2.transform.rotation = playerCamera.transform.rotation;
        Objectpt3.transform.rotation = playerCamera.transform.rotation;
    }
}
