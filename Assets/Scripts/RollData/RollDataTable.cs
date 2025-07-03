using CairnRandomizer.RollData.Equipment;
using CairnRandomizer.RollData.Names;
using CairnRandomizer.RollData.Traits;
using UnityEngine;

namespace CairnRandomizer.RollData
{
    [CreateAssetMenu(fileName = nameof(RollDataTable), menuName = "RollData/_"+nameof(RollDataTable))]
    public class RollDataTable : ScriptableObject
    {
        public EquipmentDataTable EquipmentDataTable;
        public MaleNameDataTable MaleNameDataTable;
        public FemaleNameDataTable FemaleNameDataTable;
        public SurnameDataTable SurnameDataTable;
        public TraitsDataTable TraitsDataTable;
    }
}