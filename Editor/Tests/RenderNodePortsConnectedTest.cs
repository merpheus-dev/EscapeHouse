using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Subtegral.EscapeHouse.Graph;
using System.Linq;
using XNode;
namespace Subtegral.EscapeHouse.Tests
{
    public class RenderNodePortsConnectedTest
    {
        [Test]
        public void GraphAssets_AllRenderNodes_Connected()
        {
            var graphs = Resources.LoadAll<SceneGraph>("Graphs");
            RenderNode[] renderNodes;
            bool anyNotConnectedPort = false;
            foreach (var graph in graphs)
            {
                renderNodes = graph.nodes.Where(x => x.GetType() == typeof(RenderNode)).Cast<RenderNode>().ToArray();
                foreach (var node in renderNodes)
                {
                    int notConnectedPortCount = node.InstancePorts
                                                    .Count(x => x.ValueType == typeof(ChoiceBranch) && !x.IsConnected);
                    if (notConnectedPortCount > 0)
                    {
                        anyNotConnectedPort = true;
                        break;
                    }
                }
                if (anyNotConnectedPort)
                    break;
            }
            Assert.AreEqual(false,anyNotConnectedPort);
        }

    }
}
