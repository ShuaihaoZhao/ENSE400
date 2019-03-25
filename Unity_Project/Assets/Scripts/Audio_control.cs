using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_control : MonoBehaviour
{
    public AudioClip[] ac;
    private int index;

    void Start()
    {
        index = 1;
        this.GetComponent<AudioSource>().clip = ac[0];
        this.GetComponent<AudioSource>().Play();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            this.GetComponent<AudioSource>().clip = ac[index];
            this.GetComponent<AudioSource>().Play();
            index++;
            if (index >= 4)
            {
                index = 0;
            }

        }
        /*
        else if ()
        {
            
         this.GetComponent<AudioSource>().clip = ac[2];
         this.GetComponent<AudioSource>().Play();

        }
        else if ()
        {
            
             this.GetComponent<AudioSource>().clip = ac[3];
             this.GetComponent<AudioSource>().Play();

            
        }
        */
    }

}
