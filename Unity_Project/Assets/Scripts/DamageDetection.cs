using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour {

    private float cd1 = 4f;
    private float cd2 = 0.5f;
    private float tempTime = 0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("test"+other.gameObject.name);

        if ((Time.time - tempTime) > cd1 && other.gameObject.name == "Knight_T_Pose")
        {

            other.gameObject.GetComponent<PlayerHealth>().adjHealth(-5);
            tempTime = Time.time;
        }

        if ((Time.time - tempTime) > cd2 && other.gameObject.name == "Enemy_T_Pose")
        {
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponentInParent<Health>().adjHealth(-1);
            tempTime = Time.time;
        }
        
    }
}
