using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour{


    private Transform my_transform;
    
	// Use this for initialization
	void Start () {
        my_transform = gameObject.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
        my_transform.Rotate(Vector3.up, 2f);
	}
}
