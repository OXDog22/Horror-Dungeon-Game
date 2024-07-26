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
        player = GameObject.Find("Cylinder");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z) * speed * Time.deltaTime);
    }
}