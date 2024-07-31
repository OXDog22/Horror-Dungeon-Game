using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private PlayerScript PlayerScript;
    public bool gameActive = true;
    private string Name = "Intro Scene";
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerScript = player.GetComponent<PlayerScript>();
        Debug.Log("Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive)
        {
            Debug.Log("Game over");
            GameOver.SetActive(true);
        }
    }

    public void StartFirstScene()
    {
        Debug.Log("restart");
        PlayerScript.Hp = 3;
        gameActive = true;
        SceneManager.LoadScene(Name);
        
        
    }

}
