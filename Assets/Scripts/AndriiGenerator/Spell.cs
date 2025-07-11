using System.Collections.Generic;

namespace CairnRandomizer.AndriiGenerator
{
    public class Spell : Item
    {
        public enum SpellType { Немає, Бойовий, Комбінований, Сапорт }

        public SpellType Type;

        public Spell(string name, SpellType type)
        {
            this.Name = name;
            this.Type = type;
        }

        public static SpellType GetRandomSpellType(List<int> chances = null)
        {
            List<int> dist = (chances != null && chances.Count == 4)
                ? chances
                : new List<int> { 25, 25, 25, 25 };

            int roll = UnityEngine.Random.Range(0, 100);
            int sum = 0;

            for (int i = 0; i < dist.Count; i++)
            {
                sum += dist[i];
                if (roll < sum)
                    return (SpellType)i;
            }

            return SpellType.Немає;
        }

        public static Spell GetRandomSpell(SpellType type)
        {
            return DataLibrary.GetRandomSpell(type);
        }
    }
}


