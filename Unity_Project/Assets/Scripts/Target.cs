using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public List<Transform> targets;
    public Transform selectedTarget;//enemy

    // Use this for initialization
    void Start()
    {
        targets = new List<Transform>();
        AddAllEnemies();
    }

    // Update is called once per frame
    void Update()
    {
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

    public void AddTarget(Transform t)
    {
        targets.Add(t);
    }

    private void SelectTarget()
    {
        if (selectedTarget == null)
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
