using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject Building;
    public GameObject Button;
    public TMP_Text CGold;
    public int Value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Built()
    {
        if (Int32.Parse(CGold.text) >= Value)
        {
            Building.SetActive(true);
            Button.SetActive(false);
            CGold.SetText((Int32.Parse(CGold.text) - Value).ToString());
        }
    }
}
