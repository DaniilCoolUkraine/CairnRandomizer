using CairnRandomizer.RollData;

namespace CairnRandomizer.RollGenerators
{
    public interface IRollGenerator
    {
        public string Roll(RollDataTable dataTable);
    }
}