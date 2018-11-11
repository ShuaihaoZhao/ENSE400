using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{

    private float cd1 = 4f;
    private float cd2 = 0.5f;
    private float tempTime = 0f;
    private string message;

    private Animator m_animator;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        SetHurtFalse();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("test"+other.gameObject.name);

        if ((Time.time - tempTime) > cd1 && other.gameObject.name == "Knight_T_Pose")
        {
            //m_animator.SetBool("e_hurt", true);
            other.gameObject.GetComponent<PlayerHealth>().adjHealth(-5);
            tempTime = Time.time;
        }

        if ((Time.time - tempTime) > cd2 && other.gameObject.name == "Enemy_T_Pose")
        {
            Debug.Log(other.gameObject.name);
            m_animator = other.GetComponent<Animator>();
            m_animator.SetBool("e_hurt", true);
            StartCoroutine("Message_hurt");
            other.gameObject.GetComponentInParent<Health>().adjHealth(-1);
            tempTime = Time.time;
        }

    }


    IEnumerator Message_hurt()
    {
        yield return new WaitForSeconds(0.8f);
        message = "hurt";
    }

    void SetHurtFalse()
    {
        if (message == "hurt")
        {
            m_animator.SetBool("e_hurt", false);
            message = "nothurt";
        }
    }
}
