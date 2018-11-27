using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour {


    Inventory inventory;
    public Transform parent;
    Inventory_slot[] slots;
	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.ItemChangeCallback += Inventory_UI_Update;
        slots = parent.GetComponentsInChildren<Inventory_slot>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Inventory_UI_Update()
    {
        for (int i = 0; i < slots.Length; i++)//totally 7 slots
        { 
            if (i < inventory.items.Count)//item position = slots position
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearItem();
            }
        }
        Debug.Log("Update the UI");
    }
}
