using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    private GameObject player;
    public GameObject ending;
    public Ending endingScript;
    public ParticleSystem explosionEffect;
    public bool bossFightActive = true;
    private Vector3 spawnPos;
    public GameObject tntBarrel;
    public GameObject normalBarrel;
    public GameObject bossHead;
    public int bossHp = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        StartCoroutine(SpawnBarrels());
    }

    // Update is called once per frame
    void Update()
    {
        //Bobs head
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * 3), transform.position.z);

        Vector3 playerDirection = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerDirection.normalized), Time.deltaTime);
    }


    IEnumerator SpawnBarrels() 
    {
        while (bossHp > 0)
        {
            //delay
            yield return new WaitForSeconds(Random.Range(6, 10));

            //Spawn Tnt with a 60% chance, normal barrel for a 40%

            //Generate random spawn position
            spawnPos = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));

            if (Random.Range(0, 5) < 4)
            {
                Instantiate(tntBarrel, spawnPos, tntBarrel.transform.rotation);

            }
            else
            {
                Instantiate(normalBarrel, spawnPos, normalBarrel.transform.rotation);

            }
        }

        //explode

        StartCoroutine(ExplosionSequence());
        
        

    }

    IEnumerator ExplosionSequence()
    {
        explosionEffect.Play();
        yield return new WaitForSeconds(.5f);
        explosionEffect.Play();
        yield return new WaitForSeconds(.5f);
        explosionEffect.Play();
        yield return new WaitForSeconds(.5f);

        ending.SetActive(true);
        endingScript.StartEndSequence();
        Destroy(bossHead);


    }
}
