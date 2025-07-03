using Sirenix.OdinInspector;
using UnityEngine;

namespace CairnRandomizer.RollData.Equipment
{
    [System.Serializable]
    public abstract class EquipmentData
    {
        public string Name;
        public int Id;
        public bool IsBulky;
    }

    [System.Serializable]
    public class TrinketsData : EquipmentData
    {
    }
    
    [System.Serializable]
    public class GearData : EquipmentData
    {
    }

    [System.Serializable]
    public class ToolData : EquipmentData
    {
    }

    public interface ITierable
    {
        int Tier { get; }
    }
    
    [System.Serializable]
    public class WeaponData : EquipmentData, ITierable
    {
        [MinValue(1)] public int DiceAmount;
        public DiceType Dice;
        
        [field:SerializeField] public int Tier { get; private set; }
    }

    [System.Serializable]
    public class ArmorData : EquipmentData, ITierable
    {
        [MinValue(1)] public int Armor;
        public bool IsSecondary;

        [field:SerializeField] public int Tier { get; private set; }
    }

    [System.Serializable]
    public class StorageData : EquipmentData
    {
        [MinValue(1)] public int Storage;
        public bool IsSlow;
    }
}