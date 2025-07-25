﻿using System.Collections.Generic;
using CairnRandomizer.AndriiGenerator;
using CairnRandomizer.General;
using CairnRandomizer.RollData;
using CairnRandomizer.RollGenerators;
using CairnRandomizer.RollGenerators.GeneratorData;
using SimpleEventBus.SimpleEventBus.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CairnRandomizer
{
    public class RollManager : MonoBehaviour
    {
        [SerializeField, Required] private RollDataTable _rollDataTable;
        private IRollGenerator _appearanceRollGenerator;
        private IRollGenerator _statsRollGenerator;
        private IRollGenerator _equipmentRollGenerator;

        private Gender _gender = Gender.Male;
        
        private void OnEnable()
        {
            GlobalEvents.AddListener<RollRequested>(OnRollRequestedAndrii);
            GlobalEvents.AddListener<GenderChanged>(OnGenderChanged);
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<RollRequested>(OnRollRequestedAndrii);
            GlobalEvents.RemoveListener<GenderChanged>(OnGenderChanged);
        }

        public void Initialize()
        {
            _appearanceRollGenerator =  new AppearanceRollGenerator();
            _statsRollGenerator =  new StatsRollGenerator();
            _equipmentRollGenerator =  new EquipmentRollGenerator();
        }
        
        private void OnGenderChanged(GenderChanged ev)
        {
            _gender = ev.Gender;
        }
        
        private void OnRollRequested(RollRequested ev)
        {
            var rollsData = new List<IRollData>();

            rollsData.Add(_appearanceRollGenerator.Roll(_rollDataTable));
            rollsData.Add(_statsRollGenerator.Roll(_rollDataTable));
            rollsData.Add(_equipmentRollGenerator.Roll(_rollDataTable));

            var rollsFinishedEv = new RollCompleted(rollsData);
            GlobalEvents.Publish(rollsFinishedEv);
        }

        private void OnRollRequestedAndrii(RollRequested ev)
        {
            var character = new Character();
            character.GenerateCharacter(ev.CharacterPresetType, _gender);

            var rollsFinishedEv = new RollCompletedAndrii(character);
            GlobalEvents.Publish(rollsFinishedEv);
        }
    }
}