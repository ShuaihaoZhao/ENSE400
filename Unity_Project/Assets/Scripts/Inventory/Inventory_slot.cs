﻿using UnityEngine;
using UnityEngine.UI;

public class Inventory_slot : MonoBehaviour {

    Item item;
    public Image icon;
    public Button deleteButton;
    public Sprite temp;
    // Use this for initialization

    
    public void AddItem(Item newitem)
    {
        item = newitem;
        icon.sprite = item.image;
        icon.enabled = true;
        deleteButton.interactable = true;
    }

    public void ClearItem()
    {
        item = null;
        icon.sprite = temp;
        icon.enabled = true;
        deleteButton.interactable = true;
    }

    public void DeleteFromInventory()
    {
        Inventory.instance.Remove(item);
    }

    public void Use()
    {
        if (item != null)
        {
            item.UseItem();
        }
    }
}
