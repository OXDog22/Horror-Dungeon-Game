using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadIntroScene : MonoBehaviour
{
    private GameObject player;
    private PlayerScript PlayerScript;
    private string Name = "Intro Scene";
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartFirstScene()
    {
        Debug.Log("restart");
        PlayerScript.Hp = 3;
        SceneManager.LoadScene(Name);
        
    }
}
