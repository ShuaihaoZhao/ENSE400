using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseManu : MonoBehaviour {

    public static bool gamePauseVar = false;
    public GameObject PauseManuUI;
    public AudioMixer vol;
	
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

    public void Option()
    {
        PauseManuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePauseVar = true;
    }

    public void SetVolume(float volume)
    {
        vol.SetFloat("volume", volume);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
