using System.Linq;
using System.Text;
using CairnRandomizer.General;
using CairnRandomizer.RollGenerators.GeneratorData;
using SimpleEventBus.SimpleEventBus.Runtime;
using Sirenix.Utilities;
using UnityEngine;

namespace CairnRandomizer.Localization
{
    public class PrettyLocalizer : ILocalizer
    {
        private LocalizationDatatable _localization;
        private string _languageCode = "uk";
        
        public void Initialize()
        {
            _localization = Resources.Load<LocalizationDatatable>("LocalizationDatatable");
            
            GlobalEvents.AddListener<LocalizationChanged>(OnLocalizationChanged);
        }

        public string GetAppearanceText(AppearanceRollData roll)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<size=32><b>{GetLocalizedText(ILocalizer.APPEARANCE_TITLE)}</b></size>");

            sb.Append(GetLocalizedText(roll.Name));
            sb.Append(' ');
            sb.Append(GetLocalizedText(roll.Surname));
            sb.AppendLine();

            sb.AppendLine(GetLocalizedText(roll.Background));

            sb.AppendLine(GetLocalizedText(roll.Physique));
            sb.AppendLine(GetLocalizedText(roll.Skin));
            sb.AppendLine(GetLocalizedText(roll.Hair));
            sb.AppendLine(GetLocalizedText(roll.Face));

            sb.AppendLine(GetLocalizedText(roll.Speech));
            sb.AppendLine(GetLocalizedText(roll.Clothing));

            sb.AppendLine(GetLocalizedText(roll.Vice));
            sb.AppendLine(GetLocalizedText(roll.Virtue));
            sb.AppendLine(GetLocalizedText(roll.Reputation));

            sb.AppendLine(GetLocalizedText(roll.Misfortune));
            
            return sb.ToString();
        }

        public string GetStatsText(StatsRollData statsRoll)
        {
            var sb = new StringBuilder();
            statsRoll.Rolls.Sort();

            sb.AppendLine($"<size=32><b>{GetLocalizedText(ILocalizer.ATTRIBUTES_TITLE)}</b></size>");

            foreach (var roll in statsRoll.Rolls) 
                sb.Append($"{roll}\t");

            return sb.ToString();
        }

        public string GetEquipmentText(EquipmentRollData roll)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<size=32><b>{GetLocalizedText(ILocalizer.EQUIPMENT_TITLE)}</b></size>");

            foreach (var item in roll.Items)
            {
                if (item != null)
                    sb.AppendLine($"{ILocalizer.LIST_DOT} {item.GetLocalizedName(GetLocalizedText)}");
            }

            return sb.ToString();
        }

        private void OnLocalizationChanged(LocalizationChanged ev)
        {
            _languageCode = ev.LanguageCode;
        }
        
        private string GetLocalizedText(string key)
        {
            if (_localization == null)
            {
                Debug.LogError("LocalizationDatatable not loaded.");
                return key;
            }

            if (!_localization.KeyToLocales.TryGetValue(key, out var locales))
            {
                Debug.LogWarning($"No localization found for key: {key} in language: {_languageCode}");
                return key;
            }

            var localizedEntry = locales.FirstOrDefault(l => l.LanguageCode == _languageCode);

            if (localizedEntry == null)
            {
                Debug.LogWarning($"No localization found for key: {key} in language: {_languageCode}");
                return key;
            }

            return localizedEntry.Text;
        }
    }
}