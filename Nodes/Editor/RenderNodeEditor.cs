using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;
using UnityEditor;
namespace Subtegral.EscapeHouse.Graph
{
    [CustomNodeEditor(typeof(RenderNode))]
    public class RenderNodeEditor : NodeEditor
    {
        RenderNode node;
        public override void OnBodyGUI()
        {
            serializedObject.Update();
            node = target as RenderNode;
            DrawRenderTargetWithPreview();
            DrawExecutionPorts();
            serializedObject.ApplyModifiedProperties();
        }

        public override Color GetTint()
        {
            if (node == null || node.graph == null)
                return base.GetTint(); 
            if ((node.graph as SceneGraph).GetCurrentNode() == node)
                return Color.red;
            else
                return base.GetTint();
        }

        private void DrawRenderTargetWithPreview()
        {
            NodeEditorGUILayout.PortField(GUIContent.none, target.GetInputPort("Input"), GUILayout.MinWidth(0));
            node.TargetImage = (Sprite)EditorGUILayout.ObjectField("Render:", node.TargetImage, typeof(Sprite), false);
            if (node.TargetImage != null)
                EditorGUI.DrawPreviewTexture(new Rect(GUILayoutUtility.GetLastRect().position, new Vector2(300, 100)), node.TargetImage.texture);
            GUILayout.Space(50);
        }

        private void DrawExecutionPorts()
        {
            NodeEditorGUILayout.PortField(new GUIContent("On Activate"), target.GetOutputPort("ExecuteOnEnter"), GUILayout.MinWidth(0));
            NodeEditorGUILayout.InstancePortList("ButtonExecutions", typeof(ExecutionBranch), serializedObject, NodePort.IO.Output, Node.ConnectionType.Multiple);
            NodeEditorGUILayout.InstancePortList("Branches", typeof(ChoiceBranch), serializedObject, NodePort.IO.Output, Node.ConnectionType.Override, Node.TypeConstraint.Strict);
        }

        public override int GetWidth()
        {
            return 400;
        }
    }
}