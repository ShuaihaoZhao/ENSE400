﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{

    private float cd1 = 1f;
    private float cd2 = 0.5f;
    private float tempTime = 0f;
    private string message;

    private Animator m_animator;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        SetHurtFalse();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("test: "+other.gameObject.name);

        if ((Time.time - tempTime) > cd1 && other.gameObject.name == "Knight_T_Pose")
        {
                // Debug.Log("test2: "+transform.gameObject.name);

            if (transform.gameObject.name == "Maria_sword")
            {
                int enemy_attack_number = transform.gameObject.GetComponentInParent<EnemyAttack>().Enemy_HitNum();
                //Debug.Log(enemy_attack_number);
                
                if (enemy_attack_number == 0)
                {
                    return;
                }
            }

            if (transform.gameObject.tag == "Kn_w" || transform.gameObject.name == "Paladin_J_Nordstrom_Sword")
                {
                    return;
                }
               
                //Debug.Log(transform.gameObject.name + other.gameObject.name);
                //other.gameObject.GetComponent<PlayerHealth>().adjHealth(-1);
            other.gameObject.GetComponent<Player_stats>().Get_Damage(10);
            tempTime = Time.time;
        }

        if ((Time.time - tempTime) > cd2 && other.gameObject.tag == "Enemy")
        {
            Debug.Log(transform.gameObject.name);
            if (transform.gameObject.name == "Maria_sword")
            {
                return;
            }
            if (transform.gameObject.name == "Paladin_J_Nordstrom_Sword" || transform.gameObject.name == "Halberd_A")
            {
                int attack_number = transform.gameObject.GetComponentInParent<Attack>().GetHit();
                if (attack_number == 0)
                {
                    return;
                }
            }

            if (transform.gameObject.name == "Enemy_T_Pose" )
            {
                return;
            }

            if (other.gameObject != null)
            {
                m_animator = other.GetComponent<Animator>();
                m_animator.SetBool("e_hurt", true);
                StartCoroutine("Message_hurt");
            }

            if (transform.gameObject.name == "Halberd_A")
            {
                other.gameObject.GetComponentInParent<Health>().adjHealth(-4);
            }
            else
            {
                other.gameObject.GetComponentInParent<Health>().adjHealth(-1);
            }
            tempTime = Time.time;
        }

    }


    IEnumerator Message_hurt()
    {
        yield return new WaitForSeconds(0.8f);
        message = "hurt";
    }

    void SetHurtFalse()
    {
        if (message == "hurt")
        {
            if (m_animator.gameObject == null)
            {
                return;
            }
            else
            {
                m_animator.SetBool("e_hurt", false);
                message = "nothurt";
            }
        }
    }
}
