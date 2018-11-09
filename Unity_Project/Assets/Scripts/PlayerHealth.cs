using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private Animator m_animator;
	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            m_animator.SetBool("k_death", true);
        }
	}

}
