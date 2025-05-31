using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn_Off : MonoBehaviour
{
    public GameObject Object;
    [SerializeField] private bool Turn;
    
    public void Pressed()
    {
        if (Turn)
        {
            Object.SetActive(false);
            Turn = false;
        }
        else
        {
            Object.SetActive(true);
            Turn = true;
        }
    }
}
