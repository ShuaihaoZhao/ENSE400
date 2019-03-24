using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_shoot : MonoBehaviour
{
    
    private GameObject target;
    /*public float fire_speed = 15f;

    public void Set_target(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = transform.position+transform.up;
        transform.Translate(dir.normalized * fire_speed * Time.deltaTime);

    }
    */
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Kn");
    }
    private void OnTriggerEnter(Collider other)
    {
        
    
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Kn")
        {
            target.GetComponent<Player_stats>().Get_Damage(20);
        }
        Destroy(gameObject);
    }
}
