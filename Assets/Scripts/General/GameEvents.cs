using System.Collections.Generic;
using CairnRandomizer.AndriiGenerator;
using CairnRandomizer.RollGenerators.GeneratorData;
using SimpleEventBus.SimpleEventBus.Runtime;

namespace CairnRandomizer.General
{
    public class LocalizationChanged : IEvent
    {
        public string LanguageCode { get; }

        public LocalizationChanged(string languageCode)
        {
            LanguageCode = languageCode;
        }
    }

    public class GenderChanged : IEvent
    {
        public Gender Gender { get; }

        public GenderChanged(Gender gender)
        {
            Gender = gender;
        }
    }
    
    public class RollRequested : IEvent
    {
        public RollRequested(CharacterPresetType characterPresetType)
        {
            CharacterPresetType = characterPresetType;
        }

        public CharacterPresetType CharacterPresetType { get; private set; }
    }

    public class RollCompleted : IEvent
    {
        public IReadOnlyList<IRollData> RollData { get; }

        public RollCompleted(IReadOnlyList<IRollData> rollData)
        {
            RollData = rollData;
        }
    }
    
    public class RollCompletedAndrii : IEvent
    {
        public Character Character { get; }

        public RollCompletedAndrii(Character character)
        {
            Character = character;
        }
    }

    public class AppearanceRollCompleted : IEvent
    {
        public string Background { get; }
        public string Misfortune { get; }

        public AppearanceRollCompleted(string background, string misfortune)
        {
            Background = background;
            Misfortune = misfortune;
        }
    }
    
    public class AttributesRollCompleted
    {
    }
    
    public class EquipmentRollCompleted
    {
    }
}