using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_damage : MonoBehaviour
{
    private bool first;

    private void Start()
    {
        first = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (first == true)
        {
            if (collision.gameObject.tag == "Kn")
            {
                collision.gameObject.GetComponent<Player_stats>().Get_Damage(10);
                first = false;
            }
            
        }
    }

}
