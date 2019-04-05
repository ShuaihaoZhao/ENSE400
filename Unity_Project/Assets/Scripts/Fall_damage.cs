using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_damage : MonoBehaviour
{
    private bool first;
    private GameObject knight;
    private int damage;

    private void Start()
    {
        first = true;
        knight = GameObject.FindGameObjectWithTag("Kn");
        
    }
    private void Update()
    {
        damage = knight.GetComponent<Player_stats>().armor.GetValue() + 10;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (first == true)
        {
            if (collision.gameObject.tag == "Kn")
            {
                collision.gameObject.GetComponent<Player_stats>().Get_Damage(damage);
                first = false;
            }
            
        }
    }

}
