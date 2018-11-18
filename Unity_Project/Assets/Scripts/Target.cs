using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public List<Transform> targets;
    public Transform selectedTarget;//enemy
    //public int num;

    // Use this for initialization
    void Start()
    {
        targets = new List<Transform>();
        AddAllEnemies();
        //num = targets.Count;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (CheckState())//enemy number changed return true 
        {
            AddAllEnemies();
            
        }*/
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SelectTarget();
        }
    }

    public void AddAllEnemies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in go)
        {
            AddTarget(enemy.transform);
        }

    }

    public bool CheckState()
    {
        GameObject[] check_enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in check_enemy)
        {
            if (enemy == null)
            {
                return true;
            }
        }
        return false;
    }

    public void AddTarget(Transform t)
    {
        targets.Add(t);
    }

    private void SelectTarget()
    {
        if (selectedTarget == null )
        {
            SortByDistance();
            selectedTarget = targets[0];
        }
        else 
        {
            //get the current index
            int index = targets.IndexOf(selectedTarget);

            if (index < (targets.Count - 1))
            {
                index++;
            }
            else
            {
                index = 0;
            }
            selectedTarget = targets[index];
        }

        //get the target part
        Attack k = (Attack)GetComponent<Attack>();
        k.target = selectedTarget.gameObject;
    }

    void SortByDistance()
    {
        targets.Sort((t1, t2) =>
        Vector3.Distance(transform.position, t1.position).CompareTo(Vector3.Distance(transform.position, t2.position)));
    }
}
