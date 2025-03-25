using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class get_money : MonoBehaviour
{
    public TMP_Text Ingot;
    public TMP_Text Money;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        if (Int32.Parse(Ingot.text) >= 1)
        {
            Ingot.SetText((Int32.Parse(Ingot.text) - 1).ToString());
            Money.SetText((Int32.Parse(Money.text) + 100).ToString());
        }
    }
}
