using System.Collections.Generic;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CairnRandomizer.RollData.Equipment
{
    [CreateAssetMenu(fileName = nameof(EquipmentDataTable), menuName = "RollData/"+nameof(EquipmentDataTable))]
    public class EquipmentDataTable : ScriptableObject
    {
        [SerializeReference, Searchable] public List<EquipmentData> EquipmentList;

        private void OnValidate()
        {
            Parallel.ForEach(EquipmentList, data => data.Name = data.Name.Trim());
            Parallel.ForEach(EquipmentList, data =>
            {
                if (data is ArmorData armorData)
                {
                    if (armorData.Armor < 1) 
                        Debug.LogError("Armor " + armorData.Name);
                }
                
                if (data is WeaponData weaponData)
                {
                    if (weaponData.DiceAmount < 1) 
                        Debug.LogError("Armor " + weaponData.Name);
                }
            });
        }

        [Button]
        public void AssignIds()
        {
            for (int i = 0; i < EquipmentList.Count; i++) 
                EquipmentList[i].Id = i;
        }
    }
}