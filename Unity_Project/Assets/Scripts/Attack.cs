using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject target;
    public GameObject weapen_effect;
    private Animator m_animator;
    private AnimatorStateInfo animSta;

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

        if (Input.GetMouseButton(0) && target!=null)
        {
            MyAttack();
        }

        if(Input.GetMouseButton(0) && target == null)
        {
            AttackAnimation();
        }
    }

    private void AttackAnimation()
    {
        if (animSta.IsName(BLENDTREE) && hitCount == 0 && animSta.normalizedTime > 0.5f)
        {
            m_animator.SetInteger("attack_level", 1);
            hitCount = 1;
        }
        else if (animSta.IsName(ATTACK1) && hitCount == 1 && animSta.normalizedTime > 0.6f)
        {
            m_animator.SetInteger("attack_level", 2);
            hitCount = 2;
        }
        else if (animSta.IsName(ATTACK2) && hitCount == 2 && animSta.normalizedTime > 0.8f)
        {
            m_animator.SetInteger("attack_level", 3);
            hitCount = 3;
        }
    }
    private void MyAttack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        //1 magnitude
        Vector3 dir = (target.transform.position - transform.position).normalized;

        // dir ->projection to transform.forward
        float direction = Vector3.Dot(dir, transform.forward);


        if (animSta.IsName(BLENDTREE) && hitCount == 0 && animSta.normalizedTime > 0.5f)
        {
            m_animator.SetInteger("attack_level", 1);
            hitCount = 1;
            /*
            if (direction > 0 && distance<2f)
            {
                Health eh = target.GetComponent<Health>();
                eh.adjHealth(-1);
            }*/
        }
        else if (animSta.IsName(ATTACK1) && hitCount == 1 && animSta.normalizedTime > 0.6f)
        {
            m_animator.SetInteger("attack_level", 2);
            hitCount = 2;
            /*
            if (direction > 0 && distance < 2f)
            {
                Health eh = target.GetComponent<Health>();
                eh.adjHealth(-2);
            }*/
        }
        else if (animSta.IsName(ATTACK2) && hitCount == 2 && animSta.normalizedTime > 0.8f)
        {
            m_animator.SetInteger("attack_level", 3);
            hitCount = 3;
            /*
            if (direction > 0 && distance < 2f)
            {
                Health eh = target.GetComponent<Health>();
                eh.adjHealth(-3);
            }*/

        }

    }
}
