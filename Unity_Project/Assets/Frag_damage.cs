using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frag_damage : MonoBehaviour
{
    private GameObject knight;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Kn");
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("enter");
        if (other.gameObject.tag == "Kn" && counter==0)
        {
            knight.GetComponent<Player_stats>().Get_Damage(4);
            counter = 100;
        }
        counter--;
    }
    
}
