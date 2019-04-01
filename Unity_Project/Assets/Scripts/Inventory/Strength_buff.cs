using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Strength_bottle", menuName = "Inventory/Strength_bottle")]
public class Strength_buff : Item
{
    public int strength_value;

    public override void UseItem()
    {
        base.UseItem();
        GameObject character = GameObject.FindGameObjectWithTag("Kn");

        character.GetComponent<Player_stats>().Str_animation();
        character.GetComponent<Player_stats>().damage.Add_bottle_value(strength_value);
        Remove();
    }
}
