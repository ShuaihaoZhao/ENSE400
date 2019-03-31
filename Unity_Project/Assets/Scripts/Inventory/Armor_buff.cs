using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor_bottle", menuName = "Inventory/Armor_bottle")]
public class Armor_buff : Item
{
    public int armor_value;

    public override void UseItem()
    {
        base.UseItem();
        GameObject character = GameObject.FindGameObjectWithTag("Kn");

        character.GetComponent<Player_stats>().armor.Add_bottle_value(armor_value);
        Remove();
    }
}
