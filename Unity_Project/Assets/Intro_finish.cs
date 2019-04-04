using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_finish : MonoBehaviour
{
    public GameObject switch_scene;
    public Animator txt;
    private bool first=true;
    private float timer=30f;

    private void Start()
    {
        txt.SetBool("finish", false);
    }


    private void Update()
    {

        if (timer <= 0)
        {
            txt.SetBool("finish", true);
        }
            if (txt.GetBool("finish") == true && first == true)
            {
                Change_Scene();
                first = false;
            }
        

        timer -= Time.deltaTime;
    }
    public void Change_Scene()
    {
        switch_scene.GetComponent<LevelChanger>().Go_To_Game();
    }
}
