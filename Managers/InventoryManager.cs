using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Subtegral.EscapeHouse.Managers
{
    public class InventoryManager : AbstractManager<InventoryManager>
    {
        public Inventory Inventory;

        private void Start()
        {
            Inventory = Database.CurrentInventory;
        }

        private InventoryManager() { }

        public bool CheckItemExistance(List<Item> requestedItems)
        {
            foreach (var perItem in requestedItems)
            {
                if (!Inventory.CheckItemExistance(perItem))
                    return false;
            }
            return true;
        }
    }
}