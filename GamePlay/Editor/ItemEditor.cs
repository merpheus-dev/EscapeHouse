using UnityEditor;
using UnityEngine;
using System.Linq;

namespace Subtegral.EscapeHouse.Editors
{
    [CustomEditor(typeof(Item))]
    public class ItemEditor : Editor
    {
        private Item _item;
        public override void OnInspectorGUI()
        {
            _item = target as Item;
            EditorGUILayout.LabelField("ITEM ID" + _item.Id.ToString());
            _item.Name = EditorGUILayout.TextField("Item Name:", _item.name);
            _item.name = _item.Name;
            _item.Icon = (Sprite)EditorGUILayout.ObjectField("Sprite:", _item.Icon, typeof(Sprite), false);
            EditorUtility.SetDirty(_item);
        }

        [MenuItem("Subtegral/New Item")]
        public static void CreateItemMenuHook()
        {
            var itemDB = AssetDatabase.LoadAssetAtPath<ItemDatabase>(Database.GetDatabasePath());
            if (itemDB == null)
            {
                itemDB = ScriptableObject.CreateInstance<ItemDatabase>();
                AssetDatabase.CreateAsset(itemDB, Database.GetDatabasePath());
            }
            Item item = CreateInstance<Item>();
            item.Id = itemDB.Items.Max(x => x.Id)+1;
            AssetDatabase.AddObjectToAsset(item, itemDB);
            AssetDatabase.SaveAssets();
            AssetDatabase.ImportAsset(Database.GetDatabasePath());
            Selection.activeObject = item;
            itemDB.Items.Add(item);
        }
    }
}