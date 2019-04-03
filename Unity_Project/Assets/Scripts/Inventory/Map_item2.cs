using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_item2 : Item
{
    [CreateAssetMenu(fileName = "Map_segment2", menuName = "Inventory/map_segment2")]
    public class Map_unlock : Item
    {

        public override void UseItem()
        {
            base.UseItem();
            GameObject part2 = GameObject.FindGameObjectWithTag("part2_wall");

            part2.SetActive(false);
            Remove();
        }
    }
}
