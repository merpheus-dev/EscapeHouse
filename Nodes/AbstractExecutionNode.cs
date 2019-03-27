using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Subtegral.EscapeHouse.Managers;
namespace Subtegral.EscapeHouse.Graph
{
    [NodeTint("#9bffca")]
    public abstract class AbstractExecutionNode : Node, IExecutable
    {
        [Input(typeConstraint =TypeConstraint.Strict)]
        public ExecutionBranch ConnectionPort;

        public abstract void Execute();

        public Node GetConnectedNode()
        {
            var connection = GetInputPort("ConnectionPort").Connection;
            return connection.node;
        }
    }
}