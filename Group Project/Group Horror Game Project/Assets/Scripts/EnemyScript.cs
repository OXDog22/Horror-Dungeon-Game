using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }
}