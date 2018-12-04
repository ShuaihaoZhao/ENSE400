using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject target;
    private Animator enemy_animator;
    private AnimatorStateInfo enemy_animSta;
    private Health m_heath;

    public float attackTimer;
    public float attackHitTimer;
    public float attackHitCoolDown;
    public float coolDown;
    private int hitNum;
    // Use this for initialization
    void Start()
    {
        enemy_animator = gameObject.GetComponent<Animator>();
        m_heath = gameObject.GetComponent<Health>();

        attackTimer = 0;
        attackHitTimer = 0;
        coolDown = 2f;
        hitNum = 0;
        attackHitCoolDown = 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        enemy_animSta= enemy_animator.GetCurrentAnimatorStateInfo(0);

        if (!enemy_animSta.IsName("Idel_state") && enemy_animSta.normalizedTime > 1f)
        {
            hitNum = 0;
        }

        float distance = Vector3.Distance(target.transform.position, transform.position);
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
        if (attackTimer == 0 && distance<10)
        {
            enemy_animator.SetBool("e_attack", true);
            attackTimer = coolDown;
            hitNum = 1;
        }

        
        /*
        if (hitNum == 1)
        {
            if (attackHitTimer > 0)
            {
                attackHitTimer -= Time.deltaTime;

            }
            else
            {
                attackHitTimer = attackHitCoolDown;
                hitNum = 0;
            }
        }*/



    }

    public int Enemy_HitNum()
    {
        return hitNum;
    }

    private void Attack()
    {

        float distance = Vector3.Distance(target.transform.position, transform.position);

        //1 magnitude
        Vector3 dir = (target.transform.position - transform.position).normalized;

        // dir ->projection to transform.forward
        float direction = Vector3.Dot(dir, transform.forward);

        
        /*if (distance <= 1.6f )
        {
            if (direction > 0)
            {
                PlayerHealth eh = target.GetComponentInParent<PlayerHealth>();
                eh.adjHealth(-5);
            }
        }*/
    }




}
