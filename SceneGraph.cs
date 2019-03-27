using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Subtegral.EscapeHouse.Graph;
[CreateAssetMenu]
public class SceneGraph : NodeGraph
{
    private IExecutable currentNode;

    private void OnEnable()
    {
        if (nodes.Count == 0)
            return;
        currentNode = nodes[0] as IExecutable;
    }

    private void OnDisable()
    {
        currentNode = null;
    }

    public void ExecuteNode(int current)
    {
        currentNode = (nodes[current] as IExecutable);
        currentNode.Execute();
    }
    public RenderNode GetCurrentNode()
    {
        return currentNode as RenderNode;
    }
    public void SelectBranch(int branchIndex)
    {
        RenderNode renderNode = currentNode as RenderNode;
        if (renderNode != null)
        {
            currentNode = renderNode.GetConnectedNode(branchIndex);
        }
        currentNode.Execute();
    }
}