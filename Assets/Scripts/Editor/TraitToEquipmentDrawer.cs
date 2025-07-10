using System.Collections.Generic;
using System.Linq;
using CairnRandomizer.RollData.Equipment;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace CairnRandomizer.Editor
{
    public class TraitToEquipmentDrawer : OdinValueDrawer<TraitToItemId>
    {
        private EquipmentDataTable equipmentTable;
        private TraitToEquipment editedTable;
        
        protected override void Initialize()
        {
            base.Initialize();

            equipmentTable = AssetDatabase.LoadAssetAtPath<EquipmentDataTable>("Assets/Config/EquipmentDataTable.asset");
            editedTable = AssetDatabase.LoadAssetAtPath<TraitToEquipment>("Assets/Config/TraitToEquipment.asset");
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            var traitItem = this.ValueEntry.SmartValue;

            traitItem.Trait = EditorGUILayout.TextField("Trait", traitItem.Trait);

            SirenixEditorGUI.BeginBox("Item Ids");

            if (traitItem.ItemIds != null)
            {
                for (int i = 0; i < traitItem.ItemIds.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();

                    traitItem.ItemIds[i] = EditorGUILayout.IntField(traitItem.ItemIds[i]);

                    string itemName =
                        equipmentTable.EquipmentList.FirstOrDefault(item => item.Id == traitItem.ItemIds[i])?.Name ??
                        "[Not Found]";
                    GUI.enabled = false;
                    EditorGUILayout.TextField(itemName);
                    GUI.enabled = true;

                    if (GUILayout.Button("X", GUILayout.Width(20)))
                    {
                        traitItem.ItemIds.RemoveAt(i);
                        i--;
                        EditorUtility.SetDirty(editedTable);
                    }

                    EditorGUILayout.EndHorizontal();
                }
            }
            
            if (GUILayout.Button("+ Add ID"))
            {
                if (traitItem.ItemIds == null) 
                    traitItem.ItemIds = new List<int>();

                traitItem.ItemIds.Add(0);
                EditorUtility.SetDirty(editedTable);
            }

            SirenixEditorGUI.EndBox();
        }
    }
}