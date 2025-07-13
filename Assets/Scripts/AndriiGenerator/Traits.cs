namespace CairnRandomizer.AndriiGenerator
{
    public enum Gender { Male, Female }

    public class Traits
    {
        public Gender Gender;
        public string FirstName;
        public string LastName;
        public string Build;
        public string Face;
        public string Skin;
        public string Speech;
        public string Hair;
        public string Clothing;
        public string Virtue;
        public string Reputation;
        public string Flaw;

        public static Traits GetRandomTraits(Gender gender = Gender.Male)
        {
            if (!DataLibrary.TraitsInitialized)
                DataLibrary.InitTraits();

            Traits tr = new Traits();
            tr.Gender = gender;
            tr.FirstName = (gender == Gender.Male)
                ? DataLibrary.GetRandomFromList(DataLibrary.MaleNames)
                : DataLibrary.GetRandomFromList(DataLibrary.FemaleNames);

            tr.LastName = DataLibrary.GetRandomFromList(DataLibrary.LastNames);
            tr.Build = DataLibrary.GetRandomFromList(DataLibrary.Builds);
            tr.Face = DataLibrary.GetRandomFromList(DataLibrary.Faces);
            tr.Skin = DataLibrary.GetRandomFromList(DataLibrary.Skins);
            tr.Speech = DataLibrary.GetRandomFromList(DataLibrary.Speeches);
            tr.Hair = DataLibrary.GetRandomFromList(DataLibrary.Hairs);
            tr.Clothing = DataLibrary.GetRandomFromList(DataLibrary.Clothings);
            tr.Virtue = DataLibrary.GetRandomFromList(DataLibrary.Virtues);
            tr.Reputation = DataLibrary.GetRandomFromList(DataLibrary.Reputations);
            tr.Flaw = DataLibrary.GetRandomFromList(DataLibrary.Flaws);

            return tr;
        }
    }
}