namespace CairnRandomizer.AndriiGenerator
{
    public static class UtilityFunctions
    {
        public static int Roll3d6()
        {
            return UnityEngine.Random.Range(1, 7) +
                   UnityEngine.Random.Range(1, 7) +
                   UnityEngine.Random.Range(1, 7);
        }

        public static int CeilDiv(int x, int div)
        {
            return (x + div - 1) / div;
        }
    }
}

