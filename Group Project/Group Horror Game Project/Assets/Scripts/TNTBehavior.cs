using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TNTBehavior : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    private GameObject player;
    public GameObject Boss;
    private BossManager bossManager;
    private GameManager GameManager;
    public GameObject animatedBlood;
    private PlayerScript PlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerScript = player.GetComponent<PlayerScript>();
        Boss = GameObject.Find("Boss");
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bossManager = GameObject.Find("Boss + center point").GetComponent<BossManager>();
        animatedBlood = GameObject.Find("AnimatedBlood");
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = Vector3.right * Mathf.Sin(Time.time * 3);
        //transform.localScale = Vector3.forward * Mathf.Sin(Time.time * 3);
    }

    IEnumerator CountDown() 
    { 
        yield return new WaitForSeconds(10);
        explosionParticles.Play();

        Vector3 playerDistance = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
        Vector3 bossDistance = new Vector3(Boss.transform.position.x - transform.position.x, 0, Boss.transform.position.z - transform.position.z);

        if (Mathf.Abs(playerDistance.x) < 2 && Mathf.Abs(playerDistance.z) < 2)
        {
            //player hp go bye-bye
            PlayerScript.Hp -= 1;
            if (PlayerScript.Hp < 1)
            {
                GameManager.gameActive = false;
            }

            if (PlayerScript.Hp > 0)
            {
                animatedBlood.SetActive(true);
                StartCoroutine(HurtEffects());

            }

        }

        if (Mathf.Abs(bossDistance.x) < 2 && Mathf.Abs(bossDistance.z) < 2)
        {
            //boss hp go bye-bye
            bossManager.bossHp -= 1;
            Debug.Log("Hit");
        }

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    IEnumerator HurtEffects()
    {
        yield return new WaitForSeconds(1);
        animatedBlood.SetActive(false);
        

    }
}
