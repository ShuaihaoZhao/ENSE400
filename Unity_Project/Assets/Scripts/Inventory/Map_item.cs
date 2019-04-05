using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [CreateAssetMenu(fileName = "Map_segment", menuName = "Inventory/map_segment")]
    public class Map_item : Item
    {

        public override void UseItem()
        {
            base.UseItem();
            GameObject[] part1 = GameObject.FindGameObjectsWithTag("part1_wall");
        foreach (var item in part1)
        {
            item.SetActive(false);

        }
            //part1.SetActive(false);
            Remove();
        }
    }

