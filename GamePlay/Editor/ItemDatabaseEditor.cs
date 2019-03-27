using UnityEditor;
using UnityEngine;
using UnityEditorInternal;
namespace Subtegral.EscapeHouse.Editors
{
    [CustomEditor(typeof(ItemDatabase))]
    public class ItemDatabaseEditor : Editor
    {
        ItemDatabase _db;
        public override void OnInspectorGUI()
        {
            _db = target as ItemDatabase;
            if (_db.Items.Count == 0)
                return;

            EditorGUILayout.BeginVertical();
            for (var i = 0; i < _db.Items.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(_db.Items[i].Name);
                EditorGUILayout.ObjectField(_db.Items[i], typeof(Item), false);
                GUI.color = Color.red;
                if (GUILayout.Button("DELETE"))
                {
                    AssetDatabase.RemoveObjectFromAsset(_db.Items[i]);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.ImportAsset(Database.GetDatabasePath());
                    _db.Items.RemoveAt(i);
                }
                GUI.color = Color.white;
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }
    } 
}