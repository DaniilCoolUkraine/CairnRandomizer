namespace CairnRandomizer.AndriiGenerator
{
    public class Weapon : Item
    {
        public enum WeaponType { Немає, Ближня, Дальня }
        public enum Power { Слабка, Середня, Сильна, Імба }

        public WeaponType Type;
        public Power PowerLevel;

        public Weapon(string name, WeaponType type, Power power)
        {
            this.Name = name;
            this.Type = type;
            this.PowerLevel = power;
        }

        public static WeaponType GetRandomWeaponType()
        {
            int r = UnityEngine.Random.Range(0, 2); // 0 = Ближня, 1 = Дальня
            return (r == 0) ? WeaponType.Ближня : WeaponType.Дальня;
        }

        public static Weapon GetRandomWeapon(WeaponType type)
        {
            return DataLibrary.GetRandomWeapon(type);
        }
    }
}

