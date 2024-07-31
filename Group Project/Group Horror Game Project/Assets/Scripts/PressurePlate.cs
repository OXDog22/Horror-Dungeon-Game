using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private GameObject lifting;
    private Rigidbody liftRb;

    // Start is called before the first frame update
    void Start()
    {
        liftRb = GetComponent<Rigidbody>();
        lifting = GameObject.Find("lift");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PressurePlate"))
        {
            if (lifting.transform.position.y > 12.3f)
            {
                lifting.transform.Translate(new Vector3(0, 0, -7.5f));
            }
        }
    }
}
