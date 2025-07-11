using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CairnRandomizer.RollData.Equipment
{
    [CreateAssetMenu(fileName = nameof(TraitToEquipment), menuName = "RollData/"+nameof(TraitToEquipment))]
    public class TraitToEquipment : SerializedScriptableObject
    {
        [Searchable]
        public List<TraitToItemId> TraitToItemIds;
    }

    [Serializable]
    public class TraitToItemId
    {
        public string Trait;
        public List<int> ItemIds;
    }
}