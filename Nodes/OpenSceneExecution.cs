using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Subtegral.EscapeHouse.Graph
{
    [CreateNodeMenu("Executions/Open Scene")]
    public class OpenSceneExecution : AbstractExecutionNode
    {
        public int BranchIndex;

        public override object GetValue(NodePort port)
        {
            return base.GetValue(port);
        }

        public override void Execute()
        {
            (graph as SceneGraph).SelectBranch(BranchIndex);
        }
    }
}