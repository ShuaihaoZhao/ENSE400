using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject blood;
    public GameObject healBuff;
    public int currentHealth = 10;
    public int maxHealth = 10;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void adjHealth(int adj)
    {
        if (adj < 0)
        {
            GameObject.Instantiate(blood, transform.position, Quaternion.identity);
        }
        else if (adj > 0)
        {
            GameObject.Instantiate(healBuff, transform.position, Quaternion.identity);
        }

        currentHealth += adj;
        if (currentHealth < 1)
        {
            currentHealth = 0;
        }
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
