using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reprot_stats : MonoBehaviour {


    private GameObject target;
    private int currentHealth;
    public Text stats;
    private int damage;
    private int armor;
    private int health;
    private bool ui_open;
    public Animator stats_ui;



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Kn");
        ui_open = stats_ui.GetBool("stats_open");
    }

    private void Update()
    {
        report();
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (ui_open = stats_ui.GetBool("stats_open"))
            {
                end_ui();
                Debug.Log(ui_open);
            }
            else
            {
                start_ui();
            }
        }
        
    }

    public void start_ui()
    {
        stats_ui.SetBool("stats_open", true);
    }

    public void end_ui()
    {
        stats_ui.SetBool("stats_open", false);
    }



    public void report()
    {
        damage= target.GetComponent<Player_stats>().damage.GetValue();
        armor= target.GetComponent<Player_stats>().armor.GetValue();
        health= target.GetComponent<Player_stats>().GetCurrentHealth();
        stats.text = "Health: " + health + "\n" +"Attack Damage: " + damage + "\n"+"Armor: " + armor;
    }
}
