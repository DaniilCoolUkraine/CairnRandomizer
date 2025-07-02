using SimpleEventBus.SimpleEventBus.Runtime;

namespace CairnRandomizer
{
    public class RollRequested : IEvent
    {
    }

    public abstract class RollCompleted : IEvent
    {
        public string Text { get; }

        public RollCompleted(string text)
        {
            Text = text;
        }
    }
        
    public class AppearanceRollCompleted : RollCompleted
    {
        public AppearanceRollCompleted(string text) : base(text)
        {
        }
    }
    
    public class AttributesRollCompleted : RollCompleted
    {
        public AttributesRollCompleted(string text) : base(text)
        {
        }
    }
    
    public class EquipmentRollCompleted : RollCompleted
    {
        public EquipmentRollCompleted(string text) : base(text)
        {
        }
    }
}