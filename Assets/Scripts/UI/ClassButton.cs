using CairnRandomizer.AndriiGenerator;
using CairnRandomizer.General;
using SimpleEventBus.SimpleEventBus.Runtime;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CairnRandomizer.UI
{
    public class ClassButton : MonoBehaviour
    {
        [SerializeField, Required] private TextMeshProUGUI _text;
        [SerializeField, Required] private Button _button;

        private CharacterPresetType _characterPreset;

        public void Initialize(CharacterPresetType preset)
        {
            _characterPreset = preset;
            _text.text = preset.ToString();

            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            var rollRequestedEvent = new RollRequested(_characterPreset);
            GlobalEvents.Publish(rollRequestedEvent);
        }
    }
}