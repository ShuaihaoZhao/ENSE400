using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_manager : MonoBehaviour
{
    public Animator top;
    public Animator down;
    private bool check;




    private void Start()
    {
        //UI_end();
        check = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (check)
            {
                UI_end();
                check = false;
            }
            else
            {
                UI_start();
                check = true;
            }
        }
    }

    public void UI_start()
    {
        top.SetBool("open", true);
        down.SetBool("open2", true);
    }

    public void UI_end()
    {
        top.SetBool("open", false);
        down.SetBool("open2", false);
    }

}
