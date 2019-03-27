using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subtegral.EscapeHouse.Managers;
namespace Subtegral.EscapeHouse.Graph
{
    public class TakeItemExecution : AbstractExecutionNode
    {
        public Item Item;
        public override void Execute()
        {
            InventoryManager.Instance.Inventory.AddItem(Item);
            EventDispatcher.OnItemTaken(Item);
        }
    }

}