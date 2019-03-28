using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Subtegral.EscapeHouse.Graph
{
    [CreateNodeMenu("Executions/Check Puzzle")]
    public class CheckPuzzleExecution : AbstractExecutionNode
    {
        [HideInInspector]
        public GameObject TargetPuzzle;

        [Output(connectionType = ConnectionType.Multiple)]
        public ExecutionBranch OnSuccess;

        public override void Execute()
        {
            if (TargetPuzzle == null)
                throw new PuzzleNotAssignedException("Puzzle is not assigned to node!");

            if (TargetPuzzle.GetComponent<AbstractPuzzleBase>().IsPuzzleSolved)
                (GetOutputPort("OnSuccess").Connection.node as IExecutable).Execute();
            else
                TargetPuzzle.GetComponent<AbstractPuzzleBase>().OpenPuzzle();
        }
        public override object GetValue(NodePort port)
        {
            return null;
        }
    }

}