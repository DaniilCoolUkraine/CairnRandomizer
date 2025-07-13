using System.Linq;
using CairnRandomizer.AndriiGenerator;
using CairnRandomizer.General;
using CairnRandomizer.Localization;
using CairnRandomizer.RollGenerators.GeneratorData;
using CairnRandomizer.UI;
using SimpleEventBus.SimpleEventBus.Runtime;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CairnRandomizer
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField, Required] private Button _rollButton;
        [SerializeField, Required] private Button _copyButton;

        [SerializeField, Required] private Toggle _genderToggle;

        [SerializeField, Required] private CanvasGroup _classButtonsParent;
        [SerializeField, Required] private ClassButton _classButtonPrefab;

        [SerializeField, Required] private TextMeshProUGUI _appearanceText;
        [SerializeField, Required] private TextMeshProUGUI _attributesText;
        [SerializeField, Required] private TextMeshProUGUI _equipmentText;

        [SerializeField, Required] private TMP_Dropdown _languageDropdown;

        private ILocalizer _localizer;
        private string _allTexts;

        private void OnEnable()
        {
            _rollButton.onClick.AddListener(OnRollButtonClicked);
            _languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
            _genderToggle.onValueChanged.AddListener(OnGenderChanged);

            GlobalEvents.AddListener<RollCompleted>(OnRollCompleted);
            GlobalEvents.AddListener<RollCompletedAndrii>(OnRollCompletedAndrii);
        }

        private void OnDisable()
        {
            _rollButton.onClick.RemoveListener(OnRollButtonClicked);
            _languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
            _genderToggle.onValueChanged.RemoveListener(OnGenderChanged);

            GlobalEvents.RemoveListener<RollCompleted>(OnRollCompleted);
            GlobalEvents.RemoveListener<RollCompletedAndrii>(OnRollCompletedAndrii);
        }

        public void Initialize()
        {
            _copyButton.onClick.AddListener(() => GUIUtility.systemCopyBuffer = _allTexts);
            
            _localizer = new PrettyLocalizer();
            _localizer.Initialize();

            InitializeClassButtons();
            
            OnRollButtonClicked();
        }

        private void InitializeClassButtons()
        {
            foreach (CharacterPresetType preset in System.Enum.GetValues(typeof(CharacterPresetType)))
            {
                var button = Instantiate(_classButtonPrefab, _classButtonsParent.transform);
                button.Initialize(preset);
            }
        }

        private void OnRollButtonClicked()
        {
            _classButtonsParent.gameObject.SetActive(true);
        }
        
        private void OnLanguageChanged(int arg)
        {
            var ev = new LocalizationChanged(_languageDropdown.options[arg].text);
            GlobalEvents.Publish(ev);
        }

        private void OnGenderChanged(bool arg)
        {
            var ev = new GenderChanged(arg ? Gender.Male : Gender.Female);
            GlobalEvents.Publish(ev);
        }

        private void OnRollCompleted(RollCompleted ev)
        {
            var appearanceRoll = ev.RollData.FirstOrDefault(r => r is AppearanceRollData) as AppearanceRollData;
            var statsRoll = ev.RollData.FirstOrDefault(r => r is StatsRollData) as StatsRollData;
            var equipmentRoll = ev.RollData.FirstOrDefault(r => r is EquipmentRollData) as EquipmentRollData;

            _appearanceText.text = _localizer.GetAppearanceText(appearanceRoll);
            _attributesText.text = _localizer.GetStatsText(statsRoll);
            _equipmentText.text = _localizer.GetEquipmentText(equipmentRoll);

            _classButtonsParent.gameObject.SetActive(false);
        }

        private void OnRollCompletedAndrii(RollCompletedAndrii ev)
        {
            var appearanceText = GetAppearanceText(ev.Character);
            var attributesText = GetAttributesText(ev.Character);
            var inventoryText = GetInventoryText(ev.Character);

            _appearanceText.text = appearanceText;
            _attributesText.text = attributesText;
            _equipmentText.text = inventoryText;

            _allTexts = appearanceText + '\n' + attributesText + '\n' + inventoryText;

            _classButtonsParent.gameObject.SetActive(false);
        }

        private string GetAppearanceText(Character ch)
        {
            bool isFemale = ch.Traits.Gender == Gender.Female;
            string pronoun = isFemale ? "вона" : "він";
            string possPronoun = isFemale ? "її" : "його";
            string bePast = isFemale ? "була" : "був";
            string ageWord = isFemale ? "їй" : "йому";
            string dressed = isFemale ? "вдягнена" : "вдягнений";

            int age = UtilityFunctions.Roll3d6() + 20;

            // Заголовок

            string introPhrase = isFemale ? "Її звуть" : "Його звуть";

            string result = string.Format(
                "{0} <b>{1} {2}</b>, {3} {4} років. {5} <b>{6}</b>. Раніше {7} {8} <b>{9}</b>.\n\n",
                introPhrase,
                ch.Traits.FirstName,
                ch.Traits.LastName,
                ageWord,
                age,
                char.ToUpper(pronoun[0]) + pronoun.Substring(1),
                ch.Preset.ToString(),
                pronoun,
                bePast,
                ch.Background
            );


            // Статура та зовнішність
            result += "Має <b>" + ch.Traits.Build.ToLower() + "</b> тіло, ";
            result += "шкіра <b>" + ch.Traits.Skin.ToLower() + "</b>, ";
            result += "волосся <b>" + ch.Traits.Hair.ToLower() + "</b> і ";
            result += "обличчя <b>" + ch.Traits.Face.ToLower() + "</b>.\n";
            result += char.ToUpper(pronoun[0]) + pronoun.Substring(1) + " <b>" + ch.Traits.Speech.ToLower() + "</b> розмовляє і " + dressed + " у <b>" + ch.Traits.Clothing.ToLower() + "</b> одяг.\n\n";

            // Чеснота, вада, репутація, напасть
            string ending = (ch.Traits.Gender == Gender.Female) ? "а" : "ий";
            string virtue = ch.Traits.Virtue.ToLower() + ending;
            string flaw = ch.Traits.Flaw.ToLower() + ending;
            string reputation = ch.Traits.Reputation.ToLower() + ending;
            string affliction = ch.Affliction + ending;

            result += char.ToUpper(pronoun[0]) + pronoun.Substring(1) + " вельми <b>" + virtue + "</b>, а " + possPronoun + " головна вада – <b>" + flaw + "</b>.\n";
            result += "Має репутацію <b>" + reputation + "</b>. " + possPronoun + " напасть – <b>" + affliction + "</b>.\n\n";

            return result;
        }

        private static string GetAttributesText(Character ch)
        {
            return "ХП: " + ch.HP + 
                   ", СИЛ: " + ch.STR + 
                   ", СПР: " + ch.DEX + 
                   ", ВОЛ: " + ch.WIL + "\n";
        }

        private string GetInventoryText(Character ch)
        {
            var result = "Майно:\n";

            foreach (var item in ch.Inventory) 
                result += "• " + item.Name + "\n";

            if (ch.Armor != null && !ch.Inventory.Contains(ch.Armor))
                result += "• <b>Броня: " + ch.Armor.Name + " (" + ch.Armor.ArmorAmount + " броні)</b>\n";

            if (ch.Weapon != null && !ch.Inventory.Contains(ch.Weapon))
                result += "• <b>Зброя: " + ch.Weapon.Name + "</b>\n";

            if (ch.Spell != null && !ch.Inventory.Contains(ch.Spell))
                result += "• <b>Закляття: " + ch.Spell.Name + "</b>\n";

            return result;
        }
    }
}
