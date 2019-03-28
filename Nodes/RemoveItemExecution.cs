using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subtegral.EscapeHouse.Managers;
namespace Subtegral.EscapeHouse.Graph
{
    [CreateNodeMenu(PathContainer.RemoveItem)]
    public class RemoveItemExecution : AbstractExecutionNode
    {
        public Item Item;
        public override void Execute()
        {
            InventoryManager.Instance.Inventory.RemoveItem(Item);
            EventDispatcher.OnItemRemoved?.Invoke(Item);
        }
    }
}