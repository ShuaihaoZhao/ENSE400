using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    private GameObject kn;

    private void Start()
    {
        kn = GameObject.FindGameObjectWithTag("Kn");
    }
    private void OnTriggerEnter(Collider other)
    {
      
    }


}
