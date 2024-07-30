using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobCandle : MonoBehaviour
{
    private Vector3 offSet;
    public Mesh[] CandleStages;
    public MeshFilter[] CandleParts;
    public Light CandleLight;
    
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //bobs the candle
        transform.position += transform.right * Mathf.Cos(Time.time * 2f) /256;
        transform.position += transform.up * Mathf.Cos(Time.time * 2f) / -512;
    }
}
