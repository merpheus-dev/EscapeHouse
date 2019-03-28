using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Inventory
{
    private static Inventory _instance;
    private HashSet<Item> inventoryList = new HashSet<Item>();
    public static bool HasInstance
    {
        get
        {
            return _instance != null;
        }
    }

    private Inventory() { }

    public static Inventory GetInstance()
    {
        if (_instance == null)
            _instance = new Inventory();
        return _instance;
    }

    public bool CheckItemExistance(Item item)
    {
        return inventoryList.Any(x=>x==item);
    }

    public void AddItem(Item item)
    {
        inventoryList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        inventoryList.Remove(item);
    }
}
