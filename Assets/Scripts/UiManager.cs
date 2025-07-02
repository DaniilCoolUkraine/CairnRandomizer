using SimpleEventBus.SimpleEventBus.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CairnRandomizer
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private Button _rollButton;

        [SerializeField] private TextMeshProUGUI _appearanceText;
        [SerializeField] private TextMeshProUGUI _attributesText;
        [SerializeField] private TextMeshProUGUI _equipmentText;

        private void OnEnable()
        {
            _rollButton.onClick.AddListener(OnRollButtonClicked);
            
            // GlobalEvents.AddListener();
        }

        private void OnDisable()
        {
            _rollButton.onClick.RemoveListener(OnRollButtonClicked);
        }

        private void OnRollButtonClicked()
        {
            GlobalEvents.Publish(new RollRequested());
        }
    }
}
