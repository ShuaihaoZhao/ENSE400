using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_finish : MonoBehaviour
{
    public GameObject switch_scene;
    public Animator txt;
    private bool first=true;



    private void Update()
    {
        if (txt.GetBool("finish") == true && first == true)
        {
            Change_Scene();
            first = false;
        }


    }
    public void Change_Scene()
    {
        switch_scene.GetComponent<LevelChanger>().Go_To_Game();
    }
}
