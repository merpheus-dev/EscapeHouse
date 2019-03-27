using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Subtegral.EscapeHouse.Graph;
namespace Subtegral.EscapeHouse.Managers
{
    public sealed class GraphExecutionManager : AbstractManager<GraphExecutionManager>,IExecutable,IContainer
    {
        public static SceneGraph Graph;

#pragma warning disable
        [SerializeField]
        private int currentNodeIndex;

        private GraphExecutionManager() { }

        public void Execute()
        {
            Graph.ExecuteNode(currentNodeIndex);
        }

        public void Inject(object reference)
        {
            if (reference is SceneGraph)
                Graph = reference as SceneGraph;
        }
    }

}