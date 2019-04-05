using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one inventory is created!");
        }
        instance = this;
    }
    #endregion
    public int space = 7;
    public List<Item> items = new List<Item>();
    public delegate void ItemChange();
    public ItemChange ItemChangeCallback;
	

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            return false;
        }
        items.Add(item);
        if (ItemChangeCallback != null)
        {
            ItemChangeCallback.Invoke();
        }
          
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (ItemChangeCallback != null)
        {
            ItemChangeCallback.Invoke();
        }
    }
}
