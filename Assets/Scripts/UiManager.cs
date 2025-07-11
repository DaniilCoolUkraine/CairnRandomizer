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
        [SerializeField, Required] private CanvasGroup _classButtonsParent;
        [SerializeField, Required] private ClassButton _classButtonPrefab;

        [SerializeField, Required] private TextMeshProUGUI _appearanceText;
        [SerializeField, Required] private TextMeshProUGUI _attributesText;
        [SerializeField, Required] private TextMeshProUGUI _equipmentText;

        [SerializeField, Required] private TMP_Dropdown _languageDropdown;

        private ILocalizer _localizer;

        private void OnEnable()
        {
            _rollButton.onClick.AddListener(OnRollButtonClicked);
            _languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
            
            GlobalEvents.AddListener<RollCompleted>(OnRollCompleted);
            GlobalEvents.AddListener<RollCompletedAndrii>(OnRollCompletedAndrii);
        }

        private void OnDisable()
        {
            _rollButton.onClick.RemoveListener(OnRollButtonClicked);
            _languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
            
            GlobalEvents.RemoveListener<RollCompleted>(OnRollCompleted);
            GlobalEvents.RemoveListener<RollCompletedAndrii>(OnRollCompletedAndrii);
        }

        public void Initialize()
        {
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
            _appearanceText.text =
                "Персонаж: " + ev.Character.Preset + "\n" +
                "Походження: " + ev.Character.Background + 
                ", Напасть: " + ev.Character.Affliction + 
                ", Статура: " + ev.Character.Stature + "\n";

            _attributesText.text = "ХП: " + ev.Character.HP + 
                                   ", СИЛ: " + ev.Character.STR + 
                                   ", СПР: " + ev.Character.DEX + 
                                   ", ВОЛ: " + ev.Character.WIL + "\n";

            string inventoryStr = string.Empty;
            for (int i = 0; i < ev.Character.Inventory.Count; i++)
            {
                inventoryStr += ev.Character.Inventory[i].Name;
                if (i < ev.Character.Inventory.Count - 1)
                    inventoryStr += ", ";
            }

            inventoryStr += "\n";

            string weaponName = (ev.Character.Weapon != null) ? ev.Character.Weapon.Name : "Немає";
            string spellName = (ev.Character.Spell != null) ? ev.Character.Spell.Name : "Немає";
            string armorName = (ev.Character.Armor != null) ? ev.Character.Armor.Name + " (" + ev.Character.Armor.ArmorAmount + ")" : "Немає";

            inventoryStr += "Броня: " + armorName + ", Зброя: " + weaponName + ", Закляття: " + spellName + "\n";

            _equipmentText.text = inventoryStr;
            
            _classButtonsParent.gameObject.SetActive(false);
        }
    }
}
