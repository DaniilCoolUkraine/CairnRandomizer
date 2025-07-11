namespace CairnRandomizer.AndriiGenerator
{
    public class Background
    {
        public string Name;

        public Background(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static Background GetRandomBackground()
        {
            return DataLibrary.GetRandomBackground();
        }
    }
}

