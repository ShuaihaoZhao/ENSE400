using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName="Inventory/Item")]
public class Item : ScriptableObject {

    public string item_name = "New item";
    public Sprite image = null;
    public bool isDefautItem = false;

    public virtual void UseItem()
    {
        
    }

    public void Remove()
    {
        Inventory.instance.Remove(this);
    }
}
