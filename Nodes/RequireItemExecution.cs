﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subtegral.EscapeHouse.Managers;
using Subtegral.EscapeHouse;
using XNode;

namespace Subtegral.EscapeHouse.Graph
{
    [CreateNodeMenu(PathContainer.RequireItem)]
    public class RequireItemExecution : AbstractExecutionNode
    {
        public List<Item> Requests;

        [Output(connectionType =ConnectionType.Multiple)]
        public ExecutionBranch ExecuteOnSuccess;

        public override void Execute()
        {
            if (InventoryManager.Instance.CheckItemExistance(Requests))
                (GetOutputPort("ExecuteOnSuccess").Connection.node as IExecutable).Execute();
            else
                EventDispatcher.OnItemNotExists?.Invoke();
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }

}