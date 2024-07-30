using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject playerCamera;
    private UnityEngine.UI.Text TitleName;

    // These are our Buttons
    public UnityEngine.UI.Button arrowLeft;
    public UnityEngine.UI.Button arrowRight;
    public UnityEngine.UI.Button exitButton;
    public UnityEngine.UI.Button inventoryButton;

    // these are our Inventory items
    public GameObject objectpt1;
    public GameObject objectpt2;
    public GameObject objectpt3;

    // Lets us know when Inventory is open
    private bool isInventoryOpen = false;

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
    public void OpenInventory()

     // Makes inventory items appear when Inventory opened
    {   if (isInventoryOpen == false)

        {
            Instantiate(objectpt1);
            Instantiate(objectpt2);
            Instantiate(objectpt3);
            Instantiate(arrowRight);
            Instantiate(arrowLeft);
            Instantiate(exitButton);
            isInventoryOpen = true;
        }

        playerRb.transform.rotation = playerCamera.transform.rotation;
        objectpt1.transform.rotation = playerCamera.transform.rotation;
        objectpt2.transform.rotation = playerCamera.transform.rotation;
        objectpt3.transform.rotation = playerCamera.transform.rotation;

        Destroy(inventoryButton);

    }

    public void CloseInventory()

     // Make items dissapear when Inventory closed
    {
        if (isInventoryOpen == true)
        {
            Destroy(objectpt1);
            Destroy(objectpt2);
            Destroy(objectpt3);
            Destroy(arrowRight);
            Destroy(arrowLeft);
            Destroy(exitButton);
            isInventoryOpen = false;
        }

    }

    public void LeftButton()
    {

    }

    public void RightButton()
    {

    }
}
