using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subtegral.EscapeHouse.Managers;
using Subtegral.EscapeHouse;
namespace Subtegral.EscapeHouse.Graph
{
    public class RequestItemNode : AbstractExecutionNode
    {
        public List<Item> Requests;
        public int OpenScene;
        public override void Execute()
        {
            if (InventoryManager.Instance.CheckItemExistance(Requests))
                (graph as SceneGraph).SelectBranch(OpenScene);
            else
                EventDispatcher.OnItemNotExists();
        }
    }

}