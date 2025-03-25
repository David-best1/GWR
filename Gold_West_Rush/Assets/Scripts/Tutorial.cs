using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Prev;
    public GameObject Next;
    public bool end;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press()
    {
        if (!end)
        {
            Next.SetActive(true);
        }
        Prev.SetActive(false);
    }
}
