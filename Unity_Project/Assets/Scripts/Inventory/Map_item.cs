using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_item : MonoBehaviour {

    [CreateAssetMenu(fileName = "Map_segment", menuName = "Inventory/map_segment")]
    public class Map_unlock : Item
    {

        public override void UseItem()
        {
            base.UseItem();
            GameObject part1 = GameObject.FindGameObjectWithTag("part1_wall");

            part1.SetActive(false);
            Remove();
        }
    }
}
