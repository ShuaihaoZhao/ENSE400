using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_area : MonoBehaviour
{
    public GameObject rock;
    private float time = 3f;

    private void Update()
    {
        
        if (time <= 0.5f)
        {
            Generate_rocks();
            time = 3;
            //Debug.Log("Rock");
        }
        time -= Time.deltaTime;
        //Instantiate(rock, new Vector3(Random.Range(210, 240), 60f, Random.Range(1410, 1430)), Quaternion.identity);
    }

    void Generate_rocks()
    {
        for (int i = 0; i < 8; i++)
        {
            //Debug.Log("Rock");
            Instantiate(rock, new Vector3(Random.Range(210, 240), 60f, Random.Range(1410, 1430)), Quaternion.identity);
        }
    }
}
