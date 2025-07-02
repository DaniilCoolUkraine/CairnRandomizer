using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace CairnRandomizer.RollData
{
    [CreateAssetMenu(fileName = nameof(EquipmentDataTable), menuName = "RollData/"+nameof(EquipmentDataTable))]
    public class EquipmentDataTable : ScriptableObject
    {
        [SerializeReference] public List<EquipmentData> EquipmentList;

        private void OnValidate()
        {
            Parallel.ForEach(EquipmentList, data => data.Name = data.Name.Trim());
        }
    }
}