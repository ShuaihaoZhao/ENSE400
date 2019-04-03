using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_AI : MonoBehaviour
{
    //public GameObject item;
    public Transform target;
    private int moveSpeed = 1;
    public int rotationSpeed = 1;
    public string message = "live";
    public float maxDistance;
    //private float v_y;

    private Vector3 pos = Vector3.zero;
    private Transform myTransform;
    private Animator enemy_animator;
    //private Rigidbody enemy_rig;
    //private CharacterController enemy_cc;
    //private Target enemy_list;

    public NavMeshAgent navMeshAgent_enemy;

    private void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Kn");
        //enemy_list = GameObject.FindGameObjectWithTag("Kn").GetComponent<Target>();
        enemy_animator = gameObject.GetComponent<Animator>();
        //enemy_rig = GetComponent<Rigidbody>();

        enemy_animator.SetBool("b_death", false);
        target = go.transform;
        maxDistance = 2f;
        navMeshAgent_enemy.speed = 1f;
        //enemy_cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.gameObject.name);
        Boss_health h = myTransform.gameObject.GetComponent<Boss_health>();

        if (h.GetCurrentHealth() < 40)
        {
            navMeshAgent_enemy.speed = 3f;
        }

        if (h.GetCurrentHealth() != 0)
        {
            Debug.DrawLine(target.position, myTransform.position);
            myTransform.LookAt(target.transform.position);

            if (Vector3.Distance(target.position, transform.position) > 2.3f &&
               Vector3.Distance(target.position, transform.position) < 15)
            {

                if (enemy_animator.GetBool("b_attack1") == false 
                    && enemy_animator.GetBool("e_hurt") == false
                    && enemy_animator.GetBool("b_attack2") == false)
                {

                    if (h.GetCurrentHealth() > 40)
                    {
                        enemy_animator.SetBool("b_walk", true);
                        navMeshAgent_enemy.SetDestination(target.transform.position);
                    }
                    else
                    {
                        enemy_animator.SetBool("b_run", true);
                        navMeshAgent_enemy.SetDestination(target.transform.position);
                    }
                    
                }
            }
            else
            {
                if (h.GetCurrentHealth() > 40)
                {
                    enemy_animator.SetBool("b_walk", false);
                }
                else
                {
                    enemy_animator.SetBool("b_run", false);
                }
                navMeshAgent_enemy.isStopped = true;
                navMeshAgent_enemy.ResetPath();

            }
        }
        else
        {
            Death();
            Delete();
        }
    }

    public void Death()
    {
        enemy_animator.SetBool("b_death", true);

        StartCoroutine("Message_death");
    }

    IEnumerator Message_death()
    {
        yield return new WaitForSeconds(6);
        message = "death";
    }

    public string GetDeath()
    {
        return message;
    }

    public void Delete()
    {
        GameObject part3 = GameObject.FindGameObjectWithTag("part3_wall");

        part3.SetActive(false);
        if (myTransform.gameObject.GetComponent<Boss_AI>().GetDeath() == "death")
        {
            GameObject.Destroy(myTransform.gameObject);
        }
    }
}

