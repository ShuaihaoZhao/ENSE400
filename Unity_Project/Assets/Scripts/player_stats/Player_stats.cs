using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : MonoBehaviour {

    public Stats damage;
    public Stats armor;
    public int maxHealth = 100;
    public int currenthealth;

    public void Awake()
    {
        currenthealth = maxHealth;
    }

    public void Start()
    {
        EquipmentManager.instance.changeEquipment += changeEquipment;
    
    }

    void changeEquipment(Equipment newitem)
    {
       // damage.
    }

    public void changeEquipment()
    {

    }
    public void Get_Damage(int damage_value)
    {
        damage_value -= armor.GetValue();//with armor

        if (damage_value <= 0)//if the armor is high get zero damage
        {
            damage_value = 0;
        }

        currenthealth -= damage_value;

        if (currenthealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
    }


}
