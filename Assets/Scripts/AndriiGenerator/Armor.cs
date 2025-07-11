namespace CairnRandomizer.AndriiGenerator
{
    public class Armor : Item
    {
        public int ArmorAmount;

        public Armor(string name, int amount)
        {
            Name = name;
            ArmorAmount = amount;
        }

        public static Armor GetRandomArmor()
        {
            return DataLibrary.GetRandomArmor();
        }

        public static Armor GetRandomArmor(int amount)
        {
            return DataLibrary.GetArmorByAmount(amount);
        }
    }
}


