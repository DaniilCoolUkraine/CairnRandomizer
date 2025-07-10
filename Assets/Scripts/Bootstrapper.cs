using Sirenix.OdinInspector;
using UnityEngine;

namespace CairnRandomizer
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField, Required] private RollManager _rollManager;
        [SerializeField, Required] private UiManager _uiManager;

        private void Start()
        {
            _rollManager.Initialize();
            _uiManager.Initialize();
        }
    }
}