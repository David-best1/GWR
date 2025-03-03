using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class get_gold : MonoBehaviour
{
    public TMP_Text CGold;
    public int G;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAnimationFinished()
    {
        CGold.SetText((Int32.Parse(CGold.text) + G).ToString());
    }
}
