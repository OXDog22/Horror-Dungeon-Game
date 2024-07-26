using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    public float spawnRangeX = 1;
    public float spawnRangeZ = 1;
    private float startDelay = 0;
    private float spawnInterval = 0.2f;
    public GameObject[] Raindrop;
    private int rain = 0;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cylinder");
        InvokeRepeating("SpawnRain", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

        SpawnRain();
    }

    void SpawnRain()
    {
        transform.position = player.transform.position;
        Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 10, Random.Range(-spawnRangeZ, spawnRangeZ)) + transform.position;
        Instantiate(Raindrop[rain], spawnpos, Raindrop[rain].transform.rotation);
    }

}
    
