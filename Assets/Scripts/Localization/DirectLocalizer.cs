using System.Text;
using CairnRandomizer.RollGenerators.GeneratorData;
using Sirenix.Utilities;
using UnityEngine;

namespace CairnRandomizer.Localization
{
    public class DirectLocalizer : ILocalizer
    {
        public const string APPEARANCE_TITLE = "<size=32><b>Appearance</b></size>";
        public const string ATTRIBUTES_TITLE = "<size=32><b>Attributes</b></size>";
        public const string EQUIPMENT_TITLE = "<size=32><b>Equipment</b></size>";

        public void Initialize()
        {
            Debug.Log("Initialized");
        }

        public string GetAppearanceText(AppearanceRollData roll)
        {
            var sb = new StringBuilder();

            sb.AppendLine(APPEARANCE_TITLE);
            
            sb.AppendLine(roll.Name);
            sb.AppendLine(roll.Background);

            sb.AppendLine(roll.Physique);
            sb.AppendLine(roll.Skin);
            sb.AppendLine(roll.Hair);
            sb.AppendLine(roll.Face);

            sb.AppendLine(roll.Speech);
            sb.AppendLine(roll.Clothing);

            sb.AppendLine(roll.Vice);
            sb.AppendLine(roll.Virtue);
            sb.AppendLine(roll.Reputation);

            sb.AppendLine(roll.Misfortune);

            sb.AppendLine($"Age: {roll.Age}");

            return sb.ToString();
        }

        public string GetStatsText(StatsRollData statsRoll)
        {
            statsRoll.Rolls.Sort();
            return $"{ATTRIBUTES_TITLE}\n{string.Join('\t', statsRoll)}";
        }

        public string GetEquipmentText(EquipmentRollData roll)
        {
            var sb = new StringBuilder();
            
            sb.AppendLine(EQUIPMENT_TITLE);

            foreach (var item in roll.Items) 
                sb.AppendLine($"• {item}");

            return sb.ToString();
        }
    }
}