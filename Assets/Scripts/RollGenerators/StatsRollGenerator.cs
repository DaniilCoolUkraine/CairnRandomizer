using CairnRandomizer.RollData;
using CairnRandomizer.RollGenerators.GeneratorData;
using UnityEngine;

namespace CairnRandomizer.RollGenerators
{
    public class StatsRollGenerator : IRollGenerator
    {
        public IRollData Roll(RollDataTable dataTable)
        {
            return new StatsRollData(new[] { RollForStat(), RollForStat(), RollForStat() });
        }

        private int RollForStat()
        {
            var result = 0;

            for (int i = 0; i < 3; i++) 
                result += Random.Range(1, 7);

            return result;
        }
    }
}