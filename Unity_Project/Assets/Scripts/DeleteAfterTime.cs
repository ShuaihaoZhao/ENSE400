using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour {


    public float timeCycle;
    private float realTime;
	// Use this for initialization
	void Start () {
        realTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time> (timeCycle+ realTime))
        {
            Destroy(this.gameObject);
        }
		
	}
}
