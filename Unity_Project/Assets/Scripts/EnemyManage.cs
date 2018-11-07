using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManage : MonoBehaviour {

    private Transform m_transform;
    public GameObject enemy;
    //private EnemyAI ei;
    private const int MAX_ENEMY=2;
    private int num = 0;
	// Use this for initialization
	void Start () {
        m_transform = gameObject.GetComponent<Transform>();
       // ei = GetComponent<EnemyAI>();
	}
	
	// Update is called once per frame
	void Update () {
        if (num < MAX_ENEMY)
        {
            Create();
        }
        //Delete();
	}

    public void StopGenerate()
    {
        CancelInvoke();
    }

    public void Create()
    {   
        Invoke("Generation", 2f);
        num++;
    }

    void Generation()
    {
        Vector3 pos = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));

        GameObject e = GameObject.Instantiate(enemy, pos, Quaternion.identity);
        e.GetComponent<Transform>().SetParent(m_transform);
    }

    public void Delete()
    {
        if (m_transform.gameObject.GetComponentsInChildren<Transform>() != null)
        {
            Transform[] sub_e = m_transform.GetComponentsInChildren<Transform>();


            for (int i = 1; i < sub_e.Length; i++)
            {
                if (sub_e[i].gameObject.GetComponent<EnemyAI>().GetDeath()=="death")
                {
                    GameObject.Destroy(sub_e[i].gameObject);
                    num--;
                }
            }
        }
    }
}
