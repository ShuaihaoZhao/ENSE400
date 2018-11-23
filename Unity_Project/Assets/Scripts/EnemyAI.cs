using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public GameObject item;
    public Transform target;
    public int moveSpeed = 1;
    public int rotationSpeed = 1;
    public string message = "live";
    public float maxDistance;
    private float v_y;

    private Vector3 pos = Vector3.zero;
    private Transform myTransform;
    private Animator enemy_animator;
    private Rigidbody enemy_rig;
    private CharacterController enemy_cc;
    private Target enemy_list;

    public NavMeshAgent navMeshAgent_enemy;

    private void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Kn");
        enemy_list = GameObject.FindGameObjectWithTag("Kn").GetComponent<Target>();
        enemy_animator = gameObject.GetComponent<Animator>();
        enemy_rig = GetComponent<Rigidbody>();

        enemy_animator.SetBool("e_death", false);
        target = go.transform;
        maxDistance = 2f;
        enemy_cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Health h = myTransform.gameObject.GetComponent<Health>();
        if (h.GetCurrentHealth() != 0)
        {
            Debug.DrawLine(target.position, myTransform.position);
            myTransform.LookAt(target.transform.position);
            /*myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
             Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
             */
            if (Vector3.Distance(target.position, transform.position) > maxDistance && Vector3.Distance(target.position, transform.position)<10)
            {
                if (enemy_animator.GetBool("e_attack") == false && enemy_animator.GetBool("e_hurt") == false)
                {
                    enemy_animator.SetBool("e_walk", true);
                    /*
                    v_y += Time.deltaTime * -9f;
                    Vector3 v = myTransform.forward * moveSpeed;
                    v.y = v_y;
                    //pos =myTransform.position + myTransform.forward * moveSpeed * Time.deltaTime;

                    //enemy_rig.MovePosition(pos);
                    enemy_cc.Move(v * Time.deltaTime);*/
                    navMeshAgent_enemy.SetDestination(target.transform.position);
                    //Debug.Log(Vector3.Distance(target.position, transform.position));
                    if (enemy_cc.isGrounded)
                    {
                        v_y = 0;
                    }
                }
            }
            else
            {
                enemy_animator.SetBool("e_walk", false);
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
        enemy_animator.SetBool("e_death", true);

        StartCoroutine("Message_death");
    }

    IEnumerator Message_death()
    {
        yield return new WaitForSeconds(4);
        message = "death";
    }

    public string GetDeath()
    {
        return message;
    }

    public void Delete()
    {

        if (myTransform.gameObject.GetComponent<EnemyAI>().GetDeath() == "death")
        {

            Vector3 pos = new Vector3(myTransform.position.x, 0.3f, myTransform.position.z);
          
            enemy_list.targets.Remove(myTransform);
            if (Random.Range(0, 5) >= 1)
            {
                GameObject.Instantiate(item, pos, Quaternion.identity);
            }
            GameObject.Destroy(myTransform.gameObject);
        }
    }
}
