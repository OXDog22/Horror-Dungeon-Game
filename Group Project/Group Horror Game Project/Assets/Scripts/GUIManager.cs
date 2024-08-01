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
    public UnityEngine.UI.Button inventoryButton; // pos(365, 162, 0)

    // these are our Inventory items
    public GameObject objectpt1;
    public GameObject objectpt2;
    public GameObject objectpt3;

    private Rigidbody objectpt1Rb;
    private Rigidbody objectpt2Rb;
    private Rigidbody objectpt3Rb;

    public float rotateSpeed = 40;

    // Lets us know when Inventory is open
    public bool isInventoryOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isInventoryOpen == false)
        {
            inventoryButton.gameObject.SetActive(true);
            leftArrow.gameObject.SetActive(false);
            rightArrow.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            objectpt1.gameObject.SetActive(false);
            objectpt2.gameObject.SetActive(false);
            objectpt3.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objectpt1 == isActiveAndEnabled && objectpt2 == isActiveAndEnabled && objectpt3 == isActiveAndEnabled)
        {
            objectpt1.transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
            objectpt2.transform.Rotate(Vector3.back * Time.deltaTime * rotateSpeed);
            objectpt3.transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        }
    }

    public void OpenInventory()

     // Makes inventory items appear when Inventory opened
    {   if (isInventoryOpen == false)

        {   
           // object1 rotation = new Vector3(-83, 6, 21);
           // object2 rotation = new Vector3(90, -238, -314); 
           // object3 rotation = new Vector3(-92, 0.85f, -95);
            objectpt1.gameObject.SetActive(true);
            objectpt2.gameObject.SetActive(true);
            objectpt3.gameObject.SetActive(true);
            leftArrow.gameObject.SetActive(true);
            rightArrow.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
            inventoryButton.gameObject.SetActive(false);
            isInventoryOpen = true;
        }
    }

    public void CloseInventory()

     // Makes items dissapear when Inventory closed and activates the inventory button
    {
        if (isInventoryOpen == true)
        {
            objectpt1.gameObject.SetActive(false);
            objectpt2.gameObject.SetActive(false);
            objectpt3.gameObject.SetActive(false);
            leftArrow.gameObject.SetActive(false);
            rightArrow.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            inventoryButton.gameObject.SetActive(true);
            isInventoryOpen = false;            
        }
    }
    
    public void LeftButton()
    {
        // Rotates all items to the left when the left button is pressed
        if (isInventoryOpen == true)
        {
            objectpt1Rb = objectpt1.GetComponent<Rigidbody>();
            objectpt2Rb = objectpt1.GetComponent<Rigidbody>();
            objectpt3Rb = objectpt1.GetComponent<Rigidbody>();

            objectpt1Rb.AddForce(Vector3.left * 10);

            if (objectpt1Rb.transform.position.x == objectpt2.transform.position.x)
            {
                objectpt1.transform.position = new Vector3(objectpt2.transform.position.x, objectpt1.transform.position.y, objectpt1.transform.position.z);
            }
            // objectpt1Rb.AddForce(Vector3.back * 10);

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
