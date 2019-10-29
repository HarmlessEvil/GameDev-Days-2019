using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public int id;
    public int type;

    public InventoryItem(int id, int type)
    {
        this.id = id;
        this.type = type;
    }
}

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> inventory = new List<InventoryItem>();

    public void Add(int id, int type)
    {
        inventory.Add(new InventoryItem(id, type));
    }

    public void Del(int id, int type)
    {
        inventory.Remove(new InventoryItem(id, type));
    }

    public bool Exs(int id, int type)
    {
        return inventory.Exists(ii => ii.id == id && ii.type == type);
    }
}
