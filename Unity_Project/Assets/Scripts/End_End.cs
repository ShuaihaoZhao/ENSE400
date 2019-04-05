using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_End : MonoBehaviour
{
    public GameObject switch_scene;
    public Animator txt;
    private bool first = true;
    private float timer = 35f;

    private void Start()
    {
        txt.SetBool("finish", false);
    }


    private void Update()
    {

        if (timer <= 0)
        {
            txt.SetBool("finish2", true);
        }
        if (txt.GetBool("finish2") == true && first == true)
        {
            Change_Scene();
            first = false;
        }


        timer -= Time.deltaTime;
    }
    public void Change_Scene()
    {
        switch_scene.GetComponent<LevelChanger>().Back_To_Main();
    }
}
