using CairnRandomizer.RollData;
using CairnRandomizer.RollGenerators.GeneratorData;

namespace CairnRandomizer.RollGenerators
{
    public interface IRollGenerator
    {
        public IRollData Roll(RollDataTable dataTable);
    }
}