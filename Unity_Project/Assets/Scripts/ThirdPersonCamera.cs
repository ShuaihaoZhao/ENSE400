using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public float mouse_sensitivity=5;
    public float distance = 3;
    public Transform target;//main character

    float mouse_x, mouse_y;//mouse based up and down
    private Vector2 minMax = new Vector2(0, 45);// set the suitable value

    float rotationSmooth = 0.5f;

    //used for the smoothDamp function
    Vector3 currentVelocity;
    Vector3 currntRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mouse_x += Input.GetAxis("Mouse X")*mouse_sensitivity;
        mouse_y -= Input.GetAxis("Mouse Y") * mouse_sensitivity;

        mouse_y = Mathf.Clamp(mouse_y, minMax.x, minMax.y);

        currntRotation = Vector3.SmoothDamp(currntRotation, new Vector3(mouse_y, mouse_x), ref currentVelocity, rotationSmooth);

        transform.eulerAngles = currntRotation;

        transform.position = target.position - transform.forward * distance;
    }
}
