using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    public Scrollbar HealthBar;
    public float Health = 100;
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
        Debug.Log(HealthBar.size);
    }
    /*
    public void Damage(float value)
    {
        Health -= value;
        HealthBar.size = Health / 100f;
    }*/
	
}
