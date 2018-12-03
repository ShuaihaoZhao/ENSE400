using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BuffBottle", menuName = "Inventory/BuffBottle_Item")]
public class BuffBottle_GameItem : Item {

    public int buff_value;

    public override void UseItem()
    {
        base.UseItem();
        GameObject character = GameObject.FindGameObjectWithTag("Kn");

        character.GetComponent<PlayerHealth>().adjHealth(buff_value);
        Remove();
    }
}
