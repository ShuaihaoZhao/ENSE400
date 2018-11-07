using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public float lookSmooth = 0.09f;
    float rotateVel = 0;

    //camera location (good view)
    public Vector3 view = new Vector3(0, 5, -5);

    //set a position for the object
    public Transform target;
    Vector3 destination = Vector3.zero;
    Movement m_knight_movement;
    //public GameObject m_knight_movement;

    private void Start()
    {
        SetCameraTarget(target);
    }

    private void LateUpdate()
    {
        //MoveToTarget();
        LootAtTarget();
        //MouseControll();
    }
    void SetCameraTarget(Transform target_object)
    {
        target = target_object;
        if (target.GetComponent<Movement>() != null)
        {
            m_knight_movement = target.GetComponent<Movement>();
        }
    }

   
    void MoveToTarget()
    {
        //rotate
        destination = m_knight_movement.Rotation_value * view;
        destination += target.position;
        transform.position = destination;
    }

    void LootAtTarget()
    {
        //SmoothDampAngle(current,target,speed,smooth)
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }

}
