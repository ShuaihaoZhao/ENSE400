using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public int damage;
    public int armor;
    public Equip_position position;

    public override void UseItem()
    {
        base.UseItem();
        Debug.Log("Equip " + name);
        EquipmentManager.instance.Equip(this);
        Remove();
    }
}

public enum Equip_position { weapon,shield};


