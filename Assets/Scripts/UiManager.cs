using System;
using System.Linq;
using CairnRandomizer.General;
using CairnRandomizer.Localization;
using CairnRandomizer.RollGenerators.GeneratorData;
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
        }

        private void OnDisable()
        {
            _rollButton.onClick.RemoveListener(OnRollButtonClicked);
            _languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
            
            GlobalEvents.RemoveListener<RollCompleted>(OnRollCompleted);
        }

        public void Initialize()
        {
            _localizer = new PrettyLocalizer();
            _localizer.Initialize();

            OnRollButtonClicked();
        }
        
        private void OnRollButtonClicked()
        {
            GlobalEvents.Publish(new RollRequested());
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
        }
    }
}
