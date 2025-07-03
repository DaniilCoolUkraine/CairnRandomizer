using CairnRandomizer.RollData;

namespace CairnRandomizer.RollGenerators
{
    public interface IRollGenerator
    {
        public IRollData Roll(RollDataTable dataTable);
    }
}