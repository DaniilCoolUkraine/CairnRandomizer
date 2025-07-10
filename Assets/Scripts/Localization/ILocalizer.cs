using CairnRandomizer.RollGenerators.GeneratorData;

namespace CairnRandomizer.Localization
{
    public interface ILocalizer
    {
        public const string APPEARANCE_TITLE = "Appearance";
        public const string ATTRIBUTES_TITLE = "Attributes";
        public const string EQUIPMENT_TITLE = "Equipment";
        public const string LIST_DOT = "•";
        
        public void Initialize();
        
        public string GetAppearanceText(AppearanceRollData roll);
        public string GetStatsText(StatsRollData statsRoll);
        public string GetEquipmentText(EquipmentRollData roll);
    }
}