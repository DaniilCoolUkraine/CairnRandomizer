using System.Collections.Generic;
using CairnRandomizer.RollData.Equipment;

namespace CairnRandomizer.RollGenerators.GeneratorData
{
    public class EquipmentRollData : IRollData
    {
        public List<EquipmentData> Items { get; }

        public EquipmentRollData(List<EquipmentData> items)
        {
            Items = items;
        }
    }
}