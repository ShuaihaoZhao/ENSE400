using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{

    public float maxValue = 10;
    public Health e_health;
    // Use this for initialization
    void Start()
    {

        e_health = this.gameObject.GetComponentInParent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(16 - 16 * (e_health.GetCurrentHealth() / maxValue), 0f, 0f);
        //Debug.Log(-16 + 16 * (e_health.GetCurrentHealth() / maxValue));
    }
}
