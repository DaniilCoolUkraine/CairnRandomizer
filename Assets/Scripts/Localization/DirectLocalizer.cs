using System.Text;
using CairnRandomizer.RollGenerators.GeneratorData;
using Sirenix.Utilities;
using UnityEngine;

namespace CairnRandomizer.Localization
{
    public class DirectLocalizer : ILocalizer
    {
        public void Initialize()
        {
            Debug.Log("Initialized");
        }

        public string GetAppearanceText(AppearanceRollData roll)
        {
            var sb = new StringBuilder();

            sb.AppendLine(ILocalizer.APPEARANCE_TITLE);
            
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
            var sb = new StringBuilder();
            statsRoll.Rolls.Sort();

            sb.AppendLine(ILocalizer.ATTRIBUTES_TITLE);

            foreach (var roll in statsRoll.Rolls) 
                sb.Append($"{roll}\t");

            return sb.ToString();
        }

        public string GetEquipmentText(EquipmentRollData roll)
        {
            var sb = new StringBuilder();
            
            sb.AppendLine(ILocalizer.EQUIPMENT_TITLE);

            foreach (var item in roll.Items) 
                sb.AppendLine($"{ILocalizer.LIST_DOT} {item}");

            return sb.ToString();
        }
    }
}