using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changecam : MonoBehaviour
{
    public Animator controller;
    public int type;
    public bool Pos;

    // Start is called before the first frame update
    void Start()
    {
        Pos = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Press()
    {
        if (type == 1)
        {
            if (Pos)
            {
                Pos = !Pos;
                controller.SetBool("Cave", true);
            }
            else
            {
                Pos = !Pos;
                controller.SetBool("Cave", false);
            }
        }
        else
        {
            if (Pos)
            {
                Pos = !Pos;
                controller.SetBool("Houses", true);
            }
            else
            {
                Pos = !Pos;
                controller.SetBool("Houses", false);
            }
        }
    }
}
