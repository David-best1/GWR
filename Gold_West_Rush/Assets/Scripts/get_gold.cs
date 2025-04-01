using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class get_gold : MonoBehaviour
{
    public TMP_Text Ore;
    public TMP_Text Ingot;
    public int G;
    private Bust _Bust;

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
        Ore.SetText((Int32.Parse(Ore.text) + G).ToString());
    }
    public void OnMouseDown()
    {
        if (tag == "Cave")
        {
            _Bust = GetComponent<Bust>();
            _Bust.Bust_Click();
            Ore.SetText((Int32.Parse(Ore.text) + G).ToString());
        }
        else if (tag == "Melting")
        {
            if (Int32.Parse(Ore.text) >= 10)
            {
                Ore.SetText((Int32.Parse(Ore.text) - 10).ToString());
                Ingot.SetText((Int32.Parse(Ingot.text) + 1).ToString());
            }
        }
    }
}
