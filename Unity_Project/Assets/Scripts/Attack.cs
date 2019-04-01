using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject target;

    private Animator m_animator;
    private AnimatorStateInfo animSta;
    private bool attack_lock;

    private const string BLENDTREE = "Blend Tree";
    private const string ATTACK1 = "attack1";
    private const string ATTACK2 = "attack2";
    private const string ATTACK3 = "attack3";
    private int hitCount = 0;

    public int GetHit()
    {
        return hitCount;
    }

    void Start()
    {
        m_animator = GetComponent<Animator>();
        attack_lock = false;
    }

    // Update is called once per frame
    void Update()
    {
        animSta = m_animator.GetCurrentAnimatorStateInfo(0);

        if (!animSta.IsName(BLENDTREE) && animSta.normalizedTime > 1f)
        {
            m_animator.SetInteger("attack_level", 0);
            hitCount = 0;
        }

        if (m_animator.GetBool("k_death") == false)
        {
            if (Input.GetMouseButton(1))// && target == null)
            {
                AttackAnimation();
            }
        }
    }

    private void AttackAnimation()
    {
        if (animSta.IsName(BLENDTREE) && hitCount == 0 && animSta.normalizedTime > 0.5f)
        {
            m_animator.SetInteger("attack_level", 1);
            hitCount = 1;
        }
        else if (animSta.IsName(ATTACK1) && hitCount == 1 && animSta.normalizedTime > 0.6f && attack_lock==true)
        {
            m_animator.SetInteger("attack_level", 2);
            hitCount = 2;
        }
        else if (animSta.IsName(ATTACK2) && hitCount == 2 && animSta.normalizedTime > 0.8f && attack_lock == true)
        {
            m_animator.SetInteger("attack_level", 3);
            hitCount = 3;
        }
    }

    public void Unloack_attack()
    {
        attack_lock = true;
    }
    
}
