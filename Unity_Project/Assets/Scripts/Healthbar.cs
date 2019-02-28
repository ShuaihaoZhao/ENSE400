using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    //public Scrollbar HealthBar;
    public float Health = 100;
    public Image health_image;
    private GameObject target;
    private int currentHealth;

    /*
    public RectTransform health_bar;
    private float minValue;
    private float maxValue;
    private float y_value;
    */


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Kn");
        /*
        y_value = health_bar.position.y;
        minValue = health_bar.position.x - health_bar.rect.width;
        maxValue = health_bar.position.x;*/

    }

    private void Update()
    {
        Health_UI();
    }
    public void Health_UI()
    {
        currentHealth=target.GetComponent<Player_stats>().GetCurrentHealth();
        /*
        float temp = Map(currentHealth, 0, 100, maxValue, minValue);

        health_bar.position = new Vector3(temp, y_value);*/

        //HealthBar.size= currentHealth / 100f;
        health_image.fillAmount = currentHealth / 100f;

        if (currentHealth >= 50)
        {
            health_image.color = new Color32((byte)(int)(510 * (1 - health_image.fillAmount)), 255, 0, 255);//calculated slop
        }
        else
        {
            health_image.color = new Color32(255,(byte)(int)(255-510 * (1 - health_image.fillAmount)), 0, 255);
        }

    }

    private float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x = in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }


}
