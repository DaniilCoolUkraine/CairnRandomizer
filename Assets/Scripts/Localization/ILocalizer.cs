using CairnRandomizer.RollGenerators.GeneratorData;

namespace CairnRandomizer.Localization
{
    public interface ILocalizer
    {
        public void Initialize();
        
        public string GetAppearanceText(AppearanceRollData roll);
        public string GetStatsText(StatsRollData statsRoll);
        public string GetEquipmentText(EquipmentRollData roll);
    }
}