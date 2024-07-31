using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject playerCamera;
    private UnityEngine.UI.Text TitleName;

    // These are our Buttons
    public UnityEngine.UI.Button leftArrow;
    public UnityEngine.UI.Button rightArrow;
    public UnityEngine.UI.Button exitButton;
    public UnityEngine.UI.Button inventoryButton;

    // these are our Inventory items
    public GameObject objectpt1;
    public GameObject objectpt2;
    public GameObject objectpt3;

    // Lets us know when Inventory is open
    public bool isInventoryOpen = false;

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
            Instantiate(objectpt1, new Vector3(0, 1, -8), objectpt1.transform.rotation); // rotation = new Vector3(-83, 6, 21); 
            Instantiate(objectpt2, new Vector3(-2, 1.3f, -6), objectpt2.transform.rotation); // rotation = new Vector3(90, -238, -314);
            Instantiate(objectpt3, new Vector3(2, 0.85f, -6), objectpt3.transform.rotation); // rotation = new Vector3(-92, 0.85f, -95);
            Instantiate(rightArrow, new Vector3(189, -170, 0), rightArrow.transform.rotation);
            Instantiate(leftArrow, new Vector3(-176, -169, 0), leftArrow.transform.rotation);
            Instantiate(exitButton, new Vector3(-1, -169, 0), exitButton.transform.rotation);
            isInventoryOpen = true;
        }

        playerRb.transform.rotation = playerCamera.transform.rotation;
        objectpt1.transform.rotation = playerCamera.transform.rotation;
        objectpt2.transform.rotation = playerCamera.transform.rotation;
        objectpt3.transform.rotation = playerCamera.transform.rotation;
         
       Destroy(inventoryButton);
    }

    public void CloseInventory()

     // Makes items dissapear when Inventory closed and re-creates the inventory button
    {
        if (isInventoryOpen == true)
        {
            Destroy(objectpt1);
            Destroy(objectpt2);
            Destroy(objectpt3);
            Destroy(rightArrow);
            Destroy(leftArrow);
            Destroy(exitButton);
            Instantiate(inventoryButton, new Vector3(364, 176, 0), inventoryButton.transform.rotation);
            isInventoryOpen = false;
        }
    }

    public void LeftButton()
    {
        // Rotates all items to the left when the left button is pressed
        if (isInventoryOpen == true)
        {
            objectpt1.transform.Translate(new Vector3(-10, objectpt1.transform.position.y, -10));
            objectpt2.transform.Translate(new Vector3(-50, objectpt2.transform.position.y, -50));
            objectpt3.transform.Translate(new Vector3(-100, objectpt3.transform.position.y, -100));
        } 
    }
    
    public void RightButton()
    {
        // Rotates all items to the right when the right button is pressed
        if (isInventoryOpen == true)
        {
            objectpt1.transform.Translate(new Vector3(-10, objectpt1.transform.position.y, -10));
            objectpt2.transform.Translate(new Vector3(-50, objectpt2.transform.position.y, -50));
            objectpt3.transform.Translate(new Vector3(-100, objectpt3.transform.position.y, -100));
        }
    }
}
