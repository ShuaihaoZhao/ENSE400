using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdPersonCamera : MonoBehaviour {

    public float mouse_sensitivity=1f;
    public float distance = 3;
    public Transform target;//main character


    float mouse_x, mouse_y;//mouse based up and down
    private Vector2 minMax = new Vector2(-5, 80);// set the suitable value

    float rotationSmooth = 0.2f;
    private RaycastHit hit;//define a ray

    //used for the smoothDamp function
    Vector3 currentVelocity;
    Vector3 currntRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Update_camera();

    }

    void Update_camera()
    {
        if (Physics.Linecast(target.position + Vector3.up, transform.position, out hit))//check whether the camera cross something
        {
            if (hit.collider.CompareTag("Terrain_t"))
            {
                //Debug.Log("Collistion!!!");
                transform.position = hit.point;
                distance = Vector3.Distance(target.position, transform.position);//set new distance
            }
            //return;
        }
        else
        {
            if (distance < 3)
            {
                distance = Vector3.Distance(target.position, transform.position) + Time.deltaTime;//update the distance
            }

            if (distance >5 )
            {
                distance = Vector3.Distance(target.position, transform.position) - Time.deltaTime;//update the distance
            }
        }
        mouse_x += Input.GetAxis("Mouse X") * mouse_sensitivity;
        mouse_y -= Input.GetAxis("Mouse Y") * mouse_sensitivity;

        mouse_y = Mathf.Clamp(mouse_y, minMax.x, minMax.y);
      
        currntRotation = Vector3.SmoothDamp(currntRotation, new Vector3(mouse_y, mouse_x), ref currentVelocity, rotationSmooth);

        transform.eulerAngles = currntRotation;
        
        transform.position = target.position - transform.forward * distance;
    }
}
