using CairnRandomizer.RollGenerators.GeneratorData;

namespace CairnRandomizer.Localization
{
    public interface ILocalizer
    {
        public const string APPEARANCE_TITLE = "<size=32><b>Appearance</b></size>";
        public const string ATTRIBUTES_TITLE = "<size=32><b>Attributes</b></size>";
        public const string EQUIPMENT_TITLE = "<size=32><b>Equipment</b></size>";
        public const string LIST_DOT = "•";
        
        public void Initialize();
        
        public string GetAppearanceText(AppearanceRollData roll);
        public string GetStatsText(StatsRollData statsRoll);
        public string GetEquipmentText(EquipmentRollData roll);
    }
}