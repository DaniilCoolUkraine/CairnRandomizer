using System.Collections.Generic;

namespace CairnRandomizer.AndriiGenerator
{
    public enum CharacterPresetType
    {
        Воїн,
        Лицар,
        Монах,
        Слідопит,
        Маг,
        Стрілок,
        Ельф,
        Рандомний
    }

    public class CharacterPreset
    {
        public List<int> AttributeOrder;
        public int ArmorAmount;
        public Weapon.WeaponType WeaponType;
        public List<int> TypeSpellProbability;
    }
}