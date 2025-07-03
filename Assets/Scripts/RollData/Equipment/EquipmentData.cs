using Sirenix.OdinInspector;

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
    public class ItemData : EquipmentData
    {
    }

    [System.Serializable]
    public class WeaponData : EquipmentData
    {
        [MinValue(1)] public int DiceAmount;
        public DiceType Dice;
    }

    [System.Serializable]
    public class ArmorData : EquipmentData
    {
        [MinValue(1)] public int Armor;
    }

    [System.Serializable]
    public class StorageData : EquipmentData
    {
        [MinValue(1)] public int Storage;
        public bool IsSlow;
    }
}