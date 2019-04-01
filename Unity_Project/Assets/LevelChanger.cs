﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator over;
    private int Scene_index;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Change(0);
        }
    }

    public void Change(int levelIndex)
    {
        Scene_index=levelIndex;
        over.SetTrigger("Fade_Out_trigger");
    }

    public void Complete()
    {
        SceneManager.LoadScene(Scene_index);
    }
}
