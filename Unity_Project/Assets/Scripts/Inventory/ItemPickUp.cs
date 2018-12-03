using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemPickUp: Interactable
{
    public Item item;
    private GameObject character;
    private float distance;

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Kn");
    }

    public override void Interact()
    {

        base.Interact();
        if (Input.GetKeyDown(KeyCode.C))
        {
            PickUp();
        }
    }


    void PickUp()
    {
        //Debug.Log("Pick up" + item.name);

        bool pickUp = Inventory.instance.Add(item);
        if (pickUp)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, character.transform.position);
        if (distance < 2f)
        {
            Interact();
        }

    }

}
