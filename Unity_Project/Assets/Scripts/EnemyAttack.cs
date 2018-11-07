using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject target;
    private Animator enemy_animator;
    private Health m_heath;

    public float attackTimer;
    public float coolDown;
    // Use this for initialization
    void Start()
    {
        enemy_animator = gameObject.GetComponent<Animator>();
        m_heath = gameObject.GetComponent<Health>();

        attackTimer = 0;
        coolDown = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            enemy_animator.SetBool("e_attack", false);
        }
        if (attackTimer < 0)
        {
            attackTimer = 0;
            enemy_animator.SetBool("e_attack", false);
        }
        if (attackTimer == 0)
        {
            enemy_animator.SetBool("e_attack", true);
            Attack();
            attackTimer = coolDown;
        }



    }

    private void Attack()
    {

        float distance = Vector3.Distance(target.transform.position, transform.position);

        //1 magnitude
        Vector3 dir = (target.transform.position - transform.position).normalized;

        // dir ->projection to transform.forward
        float direction = Vector3.Dot(dir, transform.forward);

        /*
        if (distance <= 3f)
        {
            if (direction > 0)
            {
                PlayerHealth eh = target.GetComponentInParent<PlayerHealth>();
                eh.adjHealth(-10);
            }
        }*/
    }
}
