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



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Kn");
    }

    private void Update()
    {
        report();
    }

    public void report()
    {
        damage= target.GetComponent<Player_stats>().damage.GetValue();
        armor= target.GetComponent<Player_stats>().armor.GetValue();
        health= target.GetComponent<Player_stats>().GetCurrentHealth();
        stats.text = "Health: " + health + "\n" +"Attack Damage: " + damage + "\n"+"Armor: " + armor;
    }
}
