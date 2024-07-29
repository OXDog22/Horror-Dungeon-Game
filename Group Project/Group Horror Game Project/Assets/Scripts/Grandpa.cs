using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Grandpa : MonoBehaviour
{
    private GameObject PlayerReference;
    private Animator GrandpaAnim;
    // Start is called before the first frame update
    void Start()
    {
        GrandpaAnim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerReference = GameObject.Find("Player");
        if (PlayerReference.transform.position.z < -15)
        {
            GrandpaAnim.SetBool("PlayerWithinRange", true);
        }
    }

    void HideTheEvidence()

    {
        Destroy(gameObject);
        //What you can't see doesn't exist =)
    }
}
