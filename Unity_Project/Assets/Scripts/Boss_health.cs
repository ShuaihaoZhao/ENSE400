using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_health : Health
{
    private int chance = 1;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 50 && chance == 1)
        {
            Debug.Log("Heal Boss");
            adjHealth(20);
            chance = 0;
        }
    }
}
