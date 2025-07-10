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
        private const string NAME_INTODUCTION_KEY = "*name_introduction*";
        private const string BACKGROUND_INTODUCTION_KEY = "*background_introduction*";
        private const string AGE_INTODUCTION_KEY = "*age_introduction*";
        private const string AGE_ENDING_KEY = "*age_ending*";
        private const string PHYSIQUE_INTODUCTION_KEY = "*physique_introduction*";
        private const string PHYSIQUE_ENDING_KEY = "*physique_ending*";
        private const string SKIN_INTODUCTION_KEY = "*skin_introduction*";
        private const string HAIR_ENDING_KEY = "*hair_ending*";
        private const string FACE_ENDING_KEY = "*face_ending*";
        private const string SPEECH_INTODUCTION_KEY = "*speech_introduction*";
        private const string SPEECH_ENDING_KEY = "*speech_ending*";
        private const string CLOTHING_INTODUCTION_KEY = "*clothing_introduction*";
        private const string CLOTHING_ENDING_KEY = "*clothing_ending*";
        private const string VICE_INTODUCTION_KEY = "*vice_introduction*";
        private const string REPUTATION_INTODUCTION_KEY = "*reputation_introduction*";
        private const string MISFORTUNE_INTODUCTION_KEY = "*misfortune_introduction*";
        
        private const string AND_KEY = "*and*";
        private const string YET_KEY = "*yet*";
        
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

            sb.Append($"{GetLocalizedText(NAME_INTODUCTION_KEY)} ");
            sb.Append($"<i>{GetLocalizedText(roll.Name)}");
            sb.Append(' ');
            sb.Append($"{GetLocalizedText(roll.Surname)}</i>");

            sb.Append(", ");

            sb.Append($"{GetLocalizedText(BACKGROUND_INTODUCTION_KEY)} ");
            sb.Append($"<i>{GetLocalizedText(roll.Background)}</i>.");
            
            sb.Append($" {GetLocalizedText(AGE_INTODUCTION_KEY)} ");
            sb.Append(roll.Age);
            sb.AppendLine($" {GetLocalizedText(AGE_ENDING_KEY)}.");

            // ------

            var introduction = GetLocalizedText(PHYSIQUE_INTODUCTION_KEY);

            if (!string.IsNullOrWhiteSpace(introduction)) 
                sb.Append($"{introduction} ");

            sb.Append(GetLocalizedText(roll.Physique));
            sb.Append($" {GetLocalizedText(PHYSIQUE_ENDING_KEY)}");

            sb.Append(", ");

            sb.Append($"{GetLocalizedText(SKIN_INTODUCTION_KEY)} ");
            sb.Append(GetLocalizedText(roll.Skin));

            sb.Append(", ");

            sb.Append(GetLocalizedText(roll.Hair));
            sb.Append($" {GetLocalizedText(HAIR_ENDING_KEY)}");

            sb.Append($" {GetLocalizedText(AND_KEY)} ");
            
            sb.Append(GetLocalizedText(roll.Face));
            sb.AppendLine($" {GetLocalizedText(FACE_ENDING_KEY)}.");

            // ------

            sb.Append($"{GetLocalizedText(SPEECH_INTODUCTION_KEY)} ");
            sb.Append(GetLocalizedText(roll.Speech));
            sb.Append($" {GetLocalizedText(SPEECH_ENDING_KEY)}.");

            sb.Append($" {GetLocalizedText(AND_KEY)} ");

            sb.Append($"{GetLocalizedText(CLOTHING_INTODUCTION_KEY)} ");
            sb.Append(GetLocalizedText(roll.Clothing));
            sb.AppendLine($" {GetLocalizedText(CLOTHING_ENDING_KEY)}.");

            // ------

            sb.Append($"{GetLocalizedText(VICE_INTODUCTION_KEY)} ");
            sb.Append(GetLocalizedText(roll.Vice));

            sb.Append($" {GetLocalizedText(YET_KEY)} ");

            sb.Append(GetLocalizedText(roll.Virtue));

            sb.Append($" {GetLocalizedText(AND_KEY)} ");

            sb.Append($"{GetLocalizedText(REPUTATION_INTODUCTION_KEY)} ");
            sb.AppendLine(GetLocalizedText(roll.Reputation));

            // ------

            sb.Append($"{GetLocalizedText(MISFORTUNE_INTODUCTION_KEY)} ");
            sb.Append(GetLocalizedText(roll.Misfortune));

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