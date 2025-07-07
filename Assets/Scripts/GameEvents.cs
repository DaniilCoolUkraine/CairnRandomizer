using System.Collections.Generic;
using CairnRandomizer.RollGenerators.GeneratorData;
using SimpleEventBus.SimpleEventBus.Runtime;

namespace CairnRandomizer
{
    public class LocalizationChanged : IEvent
    {
        public string LanguageCode { get; }

        public LocalizationChanged(string languageCode)
        {
            LanguageCode = languageCode;
        }
    }
    
    public class RollRequested : IEvent
    {
    }

    public class RollCompleted : IEvent
    {
        public IReadOnlyList<IRollData> RollData { get; }

        public RollCompleted(IReadOnlyList<IRollData> rollData)
        {
            RollData = rollData;
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