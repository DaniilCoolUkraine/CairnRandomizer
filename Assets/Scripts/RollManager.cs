using System;
using SimpleEventBus.SimpleEventBus.Runtime;
using UnityEngine;

namespace CairnRandomizer
{
    public class RollManager : MonoBehaviour
    {
        
        
        private void OnEnable()
        {
            GlobalEvents.AddListener<RollRequested>(OnRollRequested);
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<RollRequested>(OnRollRequested);
        }

        private void OnRollRequested(RollRequested ev)
        {
            
        }
    }
}