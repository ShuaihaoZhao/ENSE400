using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats{

    [SerializeField]//can be edit on unity
    private int value;
    private List<int> modifier = new List<int>();// get all value from the equipments


    public int GetValue()
    {
        int final = value;
        foreach (var temp in modifier)//add them all
            final += temp;

        return final;
    }

    public void SetValue()
    {
        value = 0;
    }

    public void Add_modifier(int value)
    {
        if (value != 0)
        {
            modifier.Add(value);
        }

    }

    public void Remove_modifier(int value)
    {
        if (value != 0)
        {
            modifier.Remove(value);
        }
    }

    public void Add_bottle_value(int temp)
    {
        value += temp;
    }
}
