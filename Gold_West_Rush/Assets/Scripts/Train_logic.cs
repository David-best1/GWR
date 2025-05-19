using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Train_logic : MonoBehaviour
{
    public bool Allowed;
    public bool Filled;
    public int Ratio = 125;
    private int Increment;
    public int Sold;
    public TMP_Text Ingot;
    public TMP_Text Money;
    public GameObject Gold;
    public GameObject Dollars;
    public void OnMouseDown()
    {
        if (Filled != true && Int32.Parse(Ingot.text) > Sold && Allowed == true)
        {
            Filled = true;
            Ingot.SetText((Int32.Parse(Ingot.text) - Sold).ToString());
            Gold.SetActive(true);
        }
    }
    public void Finished()
    {
        Gold.SetActive(false);
        if (Filled == true)
        {
            Dollars.SetActive(true);
        }
    }
    public void Arrived()
    {
        Allowed = true;
        if (Filled == true)
        {
            Filled = false;
            Increment = Sold * Ratio;
            Money.SetText((Int32.Parse(Money.text) + Increment).ToString());
            Dollars.SetActive(false);
        }
    }
    public void Passed()
    {
        Allowed = false;
    }
}
