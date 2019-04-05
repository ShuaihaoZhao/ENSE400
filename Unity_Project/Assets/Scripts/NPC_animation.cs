using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_animation : MonoBehaviour
{
    private Animation an;
    private void Start()
    {
        an = transform.GetComponent<Animation>();

    }

    private void Update()
    {
        an.Play();
    }
}
