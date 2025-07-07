using System;
using System.Linq;
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

        private ILocalizer _localizer;

        private void Start()
        {
            _localizer = new DirectLocalizer();
            _localizer.Initialize();
        }

        private void OnEnable()
        {
            _rollButton.onClick.AddListener(OnRollButtonClicked);
            GlobalEvents.AddListener<RollCompleted>(OnRollCompleted);
        }

        private void OnDisable()
        {
            _rollButton.onClick.RemoveListener(OnRollButtonClicked);
            GlobalEvents.RemoveListener<RollCompleted>(OnRollCompleted);
        }

        private void OnRollButtonClicked()
        {
            GlobalEvents.Publish(new RollRequested());
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
