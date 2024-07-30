using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobCandle : MonoBehaviour
{
    private Vector3 offSet;
    //public Mesh[] CandleStages;
    //public MeshFilter[] CandleParts;
    public GameObject[] CandlePhases;
    private Light CandleLight;
    private PlayerScript PlayerControllerScript;

    private int Hp; 
        
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        Hp = PlayerControllerScript.hp;
        offSet = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        //bobs the candle
        transform.position += transform.right * Mathf.Cos(Time.time * 2f) /256;
        transform.position += transform.up * Mathf.Cos(Time.time * 2f) / -512;

        //Update the part to correspond to HP
        // Hp can be 0 1 2 3, Candle stages range 0-23, (3 - Hp) * 6 + (CandlePartIndex) 

        // for (int i = 0; i < 6; i++)
        //{
        //int index = (3 - Hp) * 6 + i];
        //CandleParts[i].mesh = CandleStages[index];
        //this works properly
        //CandleParts[i].transform.localScale = CandleStages[index].transform.localScale;
        // }

        Hp = PlayerControllerScript.hp;

        if (Hp == 3)
        {
            CandlePhases[0].SetActive(true);
            CandlePhases[1].SetActive(false);
            CandlePhases[2].SetActive(false);
            CandlePhases[3].SetActive(false);

        }
        else if (Hp == 2)
        {
            CandlePhases[0].SetActive(false);
            CandlePhases[1].SetActive(true);
            CandlePhases[2].SetActive(false);
            CandlePhases[3].SetActive(false);

        }
        else if (Hp == 1)
        {
            CandlePhases[0].SetActive(false);
            CandlePhases[1].SetActive(false);
            CandlePhases[2].SetActive(true);
            CandlePhases[3].SetActive(false);

        }
        else if (Hp == 0)
        {
            CandlePhases[0].SetActive(false);
            CandlePhases[1].SetActive(false);
            CandlePhases[2].SetActive(false);
            CandlePhases[3].SetActive(true);

        }

    }
}
