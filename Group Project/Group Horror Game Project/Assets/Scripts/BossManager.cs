using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    private GameObject player;
    public bool bossFightActive = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Bobs head
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * 3), transform.position.z);

        Vector3 playerDirection = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerDirection.normalized), Time.deltaTime);
    }
}
