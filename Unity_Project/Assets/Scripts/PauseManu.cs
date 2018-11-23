using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManu : MonoBehaviour {

    public static bool gamePauseVar = false;
    public GameObject PauseManuUI;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePauseVar)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
		
	}


    public void Resume()
    {
        PauseManuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePauseVar = false;
    }

    public void Pause()
    {
        PauseManuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePauseVar = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
