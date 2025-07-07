namespace CairnRandomizer.RollGenerators.GeneratorData
{
    public class AppearanceRollData : IRollData
    {
        public string Name { get; }
        public string Background { get; }

        public string Misfortune { get; }
        public string Reputation { get; }
        public string Vice { get; }
        public string Virtue { get; }
        public string Clothing { get; }
        public string Speech { get; }
        public string Face { get; }
        public string Hair { get; }
        public string Skin { get; }
        public int Age { get; }
        public string Physique { get; }

        public AppearanceRollData(string name, string background, string misfortune, string reputation, string vice,
            string virtue, string clothing, string speech, string face, string hair, string skin, int age,
            string physique)
        {
            Name = name;
            Background = background;
            Misfortune = misfortune;
            Reputation = reputation;
            Vice = vice;
            Virtue = virtue;
            Clothing = clothing;
            Speech = speech;
            Face = face;
            Hair = hair;
            Skin = skin;
            Age = age;
            Physique = physique;
        }
    }
}