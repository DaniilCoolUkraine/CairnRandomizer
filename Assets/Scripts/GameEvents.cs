using SimpleEventBus.SimpleEventBus.Runtime;

namespace CairnRandomizer
{
    public class RollRequested : IEvent
    {
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