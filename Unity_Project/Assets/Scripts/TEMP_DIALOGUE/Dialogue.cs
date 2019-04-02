using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    public string name;
    [TextArea(3,10)]
    public string[] sentences;
    public string type;
    public bool conver_condition;

    public string Get_Type()
    {
        return type;
    }

    public bool Get_Dialogue_condition()
    {
        return conver_condition;
    }

    public void Set_Dialogue_condition(bool value)
    {
        conver_condition = value;
    }

}
