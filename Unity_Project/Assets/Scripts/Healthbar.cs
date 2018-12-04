using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    public Scrollbar HealthBar;
    public float Health = 100;
    public Image health_image;
    private GameObject target;
    private int currentHealth;



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Kn");
    }

    private void Update()
    {
        Health_UI();
    }
    public void Health_UI()
    {
        currentHealth=target.GetComponent<PlayerHealth>().GetCurrentHealth();
        HealthBar.size = currentHealth / 100f;

        if (HealthBar.size >= 0.5)
        {
            health_image.color = new Color32((byte)(int)(510 * (1 - HealthBar.size)), 255, 0, 255);//calculated slop
        }
        else
        {
            health_image.color = new Color32(255,(byte)(int)(255-510 * (1 - HealthBar.size)), 0, 255);
        }

    }

}
