namespace CairnRandomizer.RollGenerators.GeneratorData
{
    public class TraitRollData : IRollData
    {
        public string Name { get; }
        public string Backgrounds { get; }

        public string Misfortunes { get; }
        public string Reputation { get; }
        public string Vice { get; }
        public string Virtue { get; }
        public string Clothing { get; }
        public string Speech { get; }
        public string Face { get; }
        public string Hair { get; }
        public string Skin { get; }
        public int Age { get; }

        public TraitRollData(string name, string backgrounds, string misfortunes, string reputation, string vice, string virtue, string clothing, string speech, string face, string hair, string skin, int age)
        {
            Name = name;
            Backgrounds = backgrounds;
            Misfortunes = misfortunes;
            Reputation = reputation;
            Vice = vice;
            Virtue = virtue;
            Clothing = clothing;
            Speech = speech;
            Face = face;
            Hair = hair;
            Skin = skin;
            Age = age;
        }
    }
}