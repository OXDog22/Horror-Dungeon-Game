using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using System.Xml.Linq;

public class BackStoryManager : MonoBehaviour
{

    public GameObject backStoryCanvas;
    public TextMeshProUGUI storyText;
    public string[] story;
    private string Name = "Intro Scene";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameBackstory()
    {
        backStoryCanvas.SetActive(true);
        StartCoroutine(DisplayText());

    }

    IEnumerator DisplayText()
    {
        for (int i = 0; i < 7; i++)
        {
            storyText.text = story[i];
            yield return new WaitForSeconds(.4f);
            yield return new WaitUntil(CheckSpaceKeyPressed);
        }

        SceneManager.LoadScene(Name);
    }

    private bool CheckSpaceKeyPressed()
    {
        return Input.GetKey(KeyCode.Space);
    }

}
