using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject kn;
    public GameObject exit_port;

    private void Start()
    {
        kn = GameObject.FindGameObjectWithTag("Kn");
    }
    private void OnTriggerEnter(Collider other)
    {/*
        if (transform.gameObject.tag == "port_1")
        {
            kn.transform.position = new Vector3(62, 2, 0);
        }

        if (transform.gameObject.tag == "port_2")
        {
            kn.transform.position = new Vector3(-28, 1, 11);
        }

        if (transform.gameObject.tag == "port_3")
        {
            kn.transform.position = new Vector3(53, 2, 25);
        }

        if (transform.gameObject.tag == "port_4")
        {
            kn.transform.position = new Vector3(-28, 2, -34);
        }
        */

        kn.transform.position = exit_port.transform.position;


    }


}
