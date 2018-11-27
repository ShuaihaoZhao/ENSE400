using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdPersonCamera : MonoBehaviour {

    public float mouse_sensitivity=10f;
    public float distance = 3;
    public Transform target;//main character

    float mouse_x, mouse_y;//mouse based up and down
    private Vector2 minMax = new Vector2(10, 45);// set the suitable value

    float rotationSmooth = 0.2f;

    //used for the smoothDamp function
    Vector3 currentVelocity;
    Vector3 currntRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Update_camera();

    }

    void Update_camera()
    {
        mouse_x += Input.GetAxis("Mouse X") * mouse_sensitivity;
        mouse_y -= Input.GetAxis("Mouse Y") * mouse_sensitivity;

        mouse_y = Mathf.Clamp(mouse_y, minMax.x, minMax.y);
        /*
        if (Input.GetMouseButton(1))
        {*/
        currntRotation = Vector3.SmoothDamp(currntRotation, new Vector3(mouse_y, mouse_x), ref currentVelocity, rotationSmooth);

        transform.eulerAngles = currntRotation;
        // }
        transform.position = target.position - transform.forward * distance;
    }
}
