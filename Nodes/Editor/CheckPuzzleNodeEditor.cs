using UnityEditor;
using XNodeEditor;
using XNode;
using UnityEngine;
using System;

namespace Subtegral.EscapeHouse.Graph
{
    [CustomNodeEditor(typeof(CheckPuzzleExecution))]
    public class CheckPuzzleNodeEditor : NodeEditor
    {
        CheckPuzzleExecution targetObj;
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
            targetObj = target as CheckPuzzleExecution;
            DrawPuzzleObjectField();
            DrawPuzzleObjectNotAssignedWarning();
            EditorUtility.SetDirty(target);
        }

        private void DrawPuzzleObjectField()
        {
            targetObj.TargetPuzzle = (GameObject)EditorGUILayout.ObjectField("Puzzle:", targetObj.TargetPuzzle, typeof(GameObject), true);
        }

        private void DrawPuzzleObjectNotAssignedWarning()
        {
            if ((targetObj != null && targetObj.TargetPuzzle != null) && !targetObj.TargetPuzzle.GetComponent<AbstractPuzzleBase>())
                EditorGUILayout.HelpBox("Puzzle script not found on this prefab", MessageType.Error);
        }

    }
}