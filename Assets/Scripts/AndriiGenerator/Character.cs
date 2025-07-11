using System.Collections.Generic;
using UnityEngine;

namespace CairnRandomizer.AndriiGenerator
{
    public class Character
    {
        public CharacterPresetType Preset;
        public int HP, STR, DEX, WIL;
        public Armor Armor;
        public Background Background;
        public Affliction Affliction;
        public Weapon Weapon;
        public Spell Spell;
        public List<Item> Inventory = new List<Item>();
        public string Stature;

        public void GenerateCharacter(CharacterPresetType presetType)
        {
            CharacterPreset preset = DataLibrary.GetPreset(presetType);
            this.Preset = presetType;

            List<int> rolls = new List<int>();
            for (int i = 0; i < 4; i++)
                rolls.Add(UtilityFunctions.Roll3d6());

            if (presetType != CharacterPresetType.Рандомний)
            {
                rolls.Sort();
                rolls.Reverse();
            }
            Debug.Log("Rolls: " + rolls[0] + ", " + rolls[1] + ", " + rolls[2] + ", " + rolls[3] + ", ");

            HP = UtilityFunctions.CeilDiv(rolls[preset.AttributeOrder[0]], 3);
            STR = rolls[preset.AttributeOrder[1]];
            DEX = rolls[preset.AttributeOrder[2]];
            WIL = rolls[preset.AttributeOrder[3]];

            Armor = (presetType == CharacterPresetType.Рандомний)
                ? Armor.GetRandomArmor()
                : Armor.GetRandomArmor(preset.ArmorAmount);


            Background = Background.GetRandomBackground();
            Affliction = Affliction.GetRandomAffliction();

            Weapon = (presetType == CharacterPresetType.Рандомний)
                ? Weapon.GetRandomWeapon(Weapon.GetRandomWeaponType())
                : Weapon.GetRandomWeapon(preset.WeaponType);

            Spell = (presetType == CharacterPresetType.Рандомний)
                ? Spell.GetRandomSpell(Spell.GetRandomSpellType())
                : Spell.GetRandomSpell(Spell.GetRandomSpellType(preset.TypeSpellProbability));


            // Інвентар
            Inventory.AddRange(DataLibrary.GetItemsFromAffliction(Affliction));
            Inventory.AddRange(DataLibrary.GetItemsFromBackground(Background));
            Inventory.AddRange(DataLibrary.GetRandomItems(3));

            // Статура
            Stature = UtilityFunctions.GetRandomStature();
        }
    }
}
