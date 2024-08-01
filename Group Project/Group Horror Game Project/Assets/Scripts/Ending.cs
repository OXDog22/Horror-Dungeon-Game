using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public string[] mcDialouge;
    public string[] gDialouge;
    public TextMeshProUGUI mcText;
    public TextMeshProUGUI gText;
    private string Name = "Title Screen Scene";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEndSequence()
    {
        
        StartCoroutine(DisplayText());

    }

    IEnumerator DisplayText()
    {
        for (int i = 0; i < 7; i++)
        {
            mcText.text = mcDialouge[i];
            yield return new WaitForSeconds(.4f);
            yield return new WaitUntil(CheckSpaceKeyPressed);
            gText.text = gDialouge[i];
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
