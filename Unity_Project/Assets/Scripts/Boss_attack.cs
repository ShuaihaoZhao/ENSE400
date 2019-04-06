using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack : MonoBehaviour
{

    public GameObject target;
    private Animator enemy_animator;
    private AnimatorStateInfo enemy_animSta;
    private Boss_health m_heath;
    //public GameObject arrow;

    public float attackTimer;
    public float attackHitTimer;
    public float attackHitCoolDown;
    public float coolDown;
    private int hitNum;
    // Use this for initialization
    void Start()
    {
        enemy_animator = gameObject.GetComponent<Animator>();
        m_heath = gameObject.GetComponent<Boss_health>();

        attackTimer = 0;
        attackHitTimer = 0;
        coolDown = 2f;
        hitNum = 0;
        attackHitCoolDown = 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        
        enemy_animSta = enemy_animator.GetCurrentAnimatorStateInfo(0);
        if (m_heath.GetCurrentHealth() > 50)
        {
            if (!enemy_animSta.IsName("MKnight_1H_IDLE") && enemy_animSta.normalizedTime > 1f)
            {
                hitNum = 0;
            }

            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                enemy_animator.SetBool("b_attack1", false);
            }
            if (attackTimer < 0)
            {
                attackTimer = 0;
                enemy_animator.SetBool("b_attack1", false);

            }
            if (attackTimer == 0 && distance < 5)
            {
                enemy_animator.SetBool("b_attack1", true);
                attackTimer = coolDown;
                hitNum = 1;
            }
        }
        else
        {
            if (!enemy_animSta.IsName("MKnight_1H_IDLE") && enemy_animSta.normalizedTime > 1f)
            {
                hitNum = 0;
            }

            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                enemy_animator.SetBool("b_attack2", false);
            }
            if (attackTimer < 0)
            {
                attackTimer = 0;
                enemy_animator.SetBool("b_attack2", false);

            }
            if (attackTimer == 0 && distance < 5)
            {
                enemy_animator.SetBool("b_attack2", true);
                attackTimer = coolDown;
                hitNum = 1;
            }
        }

    }

    public int Enemy_HitNum()
    {
        return hitNum;
    }


}

