using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CairnRandomizer.Localization
{
    [CreateAssetMenu(fileName = nameof(LocalizationDatatable), menuName = nameof(LocalizationDatatable))]
    public class LocalizationDatatable : SerializedScriptableObject 
    {
        [Searchable]
        public Dictionary<string, List<Locale>> KeyToLocales;
    }
}