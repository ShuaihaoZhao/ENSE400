using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Camera main_camera;
    public float maxValue = 10;
    private Health e_health;
    private Boss_health b_health;
    //public Transform target;
    public Image eh;

    // Use this for initialization
    void Start()
    {
        if (transform.name == "Dismounted_Knight_Prefab")
        {
            e_health = this.gameObject.GetComponentInParent<Boss_health>();
        }
        else
        {
            e_health = this.gameObject.GetComponentInParent<Health>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(main_camera.transform.rotation * Vector3.forward + transform.position,
                    main_camera.transform.rotation * Vector3.up);

    
        //Vector2 hp = Camera.main.WorldToScreenPoint(target.transform.position);
        eh.fillAmount = e_health.GetCurrentHealth() / maxValue;
        //transform.localPosition = new Vector2(16 - 16 * (e_health.GetCurrentHealth() / maxValue), 0f);
        //Debug.Log(-16 + 16 * (e_health.GetCurrentHealth() / maxValue));
    }
}
