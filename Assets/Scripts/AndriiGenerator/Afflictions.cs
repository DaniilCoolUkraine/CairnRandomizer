namespace CairnRandomizer.AndriiGenerator
{
    public class Affliction
    {
        public string Name;

        public Affliction(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static Affliction GetRandomAffliction()
        {
            return DataLibrary.GetRandomAffliction();
        }
    }
}

