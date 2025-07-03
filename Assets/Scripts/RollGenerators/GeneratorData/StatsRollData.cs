namespace CairnRandomizer.RollGenerators.GeneratorData
{
    public class StatsRollData : IRollData
    {
        public int[] Rolls { get; }

        public StatsRollData(int[] ints)
        {
            Rolls = ints;
        }
    }
}