using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{

    public GameObject animatedBlood;
    private GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerHurt()
    {
        animatedBlood.SetActive(true);
        StartCoroutine(HurtEffects());


    }

    public void GameOver()

    {
        GameManager.gameActive = false;

    }
    IEnumerator HurtEffects()
    {
        yield return new WaitForSeconds(1);
        animatedBlood.SetActive(false);


    }
}
