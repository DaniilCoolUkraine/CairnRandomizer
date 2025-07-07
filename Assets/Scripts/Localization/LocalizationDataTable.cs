using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace CairnRandomizer.Localization
{
    [CreateAssetMenu(fileName = nameof(LocalizationDatatable), menuName = nameof(LocalizationDatatable))]
    public class LocalizationDatatable : SerializedScriptableObject 
    {
        public Dictionary<string, List<Locale>> KeyToLocales;

        [Button]
        public void AddData()
        { 
            EditorUtility.SetDirty(this);
        }
    }
}