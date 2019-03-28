using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;
using System.Reflection;
using System;
using UnityEngine.UI;
using Subtegral.EscapeHouse.Managers;
namespace Subtegral.EscapeHouse.Graph
{
    [CreateNodeMenu("Render Node")]
    [NodeTint("#ff9bbe")]
    public class RenderNode : Node, IExecutable
    {
        public Sprite TargetImage;

        [Input(typeConstraint = TypeConstraint.Strict)]
        public ChoiceBranch Input;

        [Output(connectionType = ConnectionType.Multiple)]
        public ExecutionBranch ExecuteOnEnter;

        [Output(instancePortList = true, connectionType = ConnectionType.Multiple)]
        public List<ExecutionBranch> ButtonExecutions = new List<ExecutionBranch>();

        [Output(instancePortList = false)]
        public List<ChoiceBranch> Branches = new List<ChoiceBranch>();

        [NonSerialized]
        private List<NodePort> branchPorts;

        [NonSerialized]
        private List<NodePort> buttonPorts;

        public override object GetValue(NodePort port)
        {
            return null;
        }

        public RenderNode GetConnectedNode(int branchIndex)
        {
            GetBranchingNodePortList();
            CheckEmptyBranchPorts();
            CheckBranchSizeWithIndex(branchIndex);
            return branchPorts[branchIndex].Connection.node as RenderNode;
        }

        private void GetBranchingNodePortList()
        {
            var portFiltered = InstancePorts.ToList();
            branchPorts = portFiltered
                          .Where(x => x.ValueType==typeof(ChoiceBranch))
                          .ToList();
        }

        private void CheckEmptyBranchPorts()
        {
            if (branchPorts.Any(x => !x.IsConnected))
                throw new BranchPortNotConnectedException("[!] Active node's branch port(s) are not connected. Make sure that they are connected");
        }

        private void CheckBranchSizeWithIndex(int branchIndex)
        {
            if (branchPorts.Count() <= branchIndex)
                throw new BranchNotExistsException("Index that you want to select appears to be not exists in current node.");
        }

        void IExecutable.Execute()
        {
            UIManager.Instance.DisposeButtons();
            ExecuteAwakeCalls();
            BindExecutionsToButtons();
        }


        private void ExecuteAwakeCalls()
        {
            var nodePort = GetOutputPort("ExecuteOnEnter");
            for (int i = 0; i < nodePort.ConnectionCount; i++)
            {
                (nodePort.GetConnections()[i].node as AbstractExecutionNode).Execute();
            }
        }

        private void BindExecutionsToButtons()
        {
            buttonPorts = InstancePorts
                              .ToList()
                              .Where(x => x.IsConnected && x.Connection.node.GetType().IsSubclassOf(typeof(AbstractExecutionNode)))
                              .ToList();
            for (int i = 0; i < buttonPorts.Count; i++)
            {
                ExecuteCommandsInPort(i);
            }
        }

        private void ExecuteCommandsInPort(int portIndex)
        {
            var port = buttonPorts[portIndex];
            if (port.IsConnected)
            {
                Button buttonInstance = UIManager.Instance.GetButtonInstance(ButtonExecutions[portIndex].Target);
                for (int i = 0; i < port.ConnectionCount; i++)
                {
                    var node = port.GetConnections()[i].node;
                    if (node.GetType().IsSubclassOf(typeof(AbstractExecutionNode)))
                    {
                        buttonInstance.onClick.AddListener(() =>
                        {
                            (node as AbstractExecutionNode).Execute();
                        });
                    }
                }
            }
        }
    }

    [System.Serializable]
    public class ExecutionBranch
    {
        public Button Target;
    }

    [System.Serializable]
    public class ChoiceBranch { }

}