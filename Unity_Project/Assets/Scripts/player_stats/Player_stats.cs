﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : Health {

    private Animator m_animator;
    public Stats damage;
    public Stats armor;
    public GameObject switch_scene;
    private bool knight_death;
    

    public void Awake()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        knight_death = false;


    }

    public void Start()
    {
        m_animator = GetComponent<Animator>();
        EquipmentManager.instance.changeEquipment += changeEquipment;
        m_animator.SetBool("k_death", false);

    }

    private void Update()
    {
        if (knight_death)
        {
            Change_Scene();
        }

        if (currentHealth <= 0)
        {

            currentHealth = 0;
            Die();
        }
    }

    void changeEquipment(Equipment newitem, Equipment olditem)
    {
        if (newitem != null)
        {
            armor.Add_modifier(newitem.armor);
            damage.Add_modifier(newitem.damage);
        }

        if (olditem != null)
        {
            armor.Remove_modifier(olditem.armor);
            damage.Remove_modifier(olditem.damage);
        }
    }


    public void Get_Damage(int damage_value)
    {
        Damage_animation();
        damage_value -= armor.GetValue();//with armor

        if (damage_value <= 0)//if the armor is high get zero damage
        {
            damage_value = 0;
        }

        currentHealth -= damage_value;

        if (currentHealth <= 0)
        {

            currentHealth = 0;
            Die();
            
        }
    }

    public void Heal(int value)
    {
        Heal_animation();
        currentHealth += value;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public int damage_value()
    {
        return damage.GetValue();
    }

    public void Die()
    {
        m_animator.SetBool("k_death", true);

        StartCoroutine("Change_Scene_Message");

    }

    IEnumerator Change_Scene_Message()
    {
        yield return new WaitForSeconds(2);
        knight_death = true;
        
    }

    public void Change_Scene()
    {
        switch_scene.GetComponent<LevelChanger>().Go_To_Gameover();
    }


}
