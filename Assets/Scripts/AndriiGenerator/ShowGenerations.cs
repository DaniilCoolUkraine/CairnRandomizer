using UnityEngine;

namespace CairnRandomizer.AndriiGenerator
{
    public class ShowGenerations : MonoBehaviour
    {
        // void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.Alpha1))
        //         GenerateAndPrint(CharacterPresetType.Лицар);
        //
        //     if (Input.GetKeyDown(KeyCode.Alpha2))
        //         GenerateAndPrint(CharacterPresetType.Воїн);
        //
        //     if (Input.GetKeyDown(KeyCode.Alpha3))
        //         GenerateAndPrint(CharacterPresetType.Монах);
        //
        //     if (Input.GetKeyDown(KeyCode.Alpha4))
        //         GenerateAndPrint(CharacterPresetType.Слідопит);
        //
        //     if (Input.GetKeyDown(KeyCode.Alpha5))
        //         GenerateAndPrint(CharacterPresetType.Маг);
        //
        //     if (Input.GetKeyDown(KeyCode.Alpha6))
        //         GenerateAndPrint(CharacterPresetType.Стрілок);
        //
        //     if (Input.GetKeyDown(KeyCode.Alpha7))
        //         GenerateAndPrint(CharacterPresetType.Ельф);
        //
        //     if (Input.GetKeyDown(KeyCode.Alpha8))
        //         GenerateAndPrint(CharacterPresetType.Рандомний);
        // }

        void GenerateAndPrint(CharacterPresetType preset)
        {
            for (int i = 0; i < 3; i++)
            {
                Character ch = new Character();
                ch.GenerateCharacter(preset);
                Debug.Log(FormatCharacter(ch));
            }
        }

        string FormatCharacter(Character ch)
        {
            string inventoryStr = "";
            for (int i = 0; i < ch.Inventory.Count; i++)
            {
                inventoryStr += ch.Inventory[i].Name;
                if (i < ch.Inventory.Count - 1)
                    inventoryStr += ", ";
            }

            string weaponName = (ch.Weapon != null) ? ch.Weapon.Name : "Немає";
            string spellName = (ch.Spell != null) ? ch.Spell.Name : "Немає";
            string armorName = (ch.Armor != null) ? ch.Armor.Name + " (" + ch.Armor.ArmorAmount + ")" : "Немає";

            string result = "Персонаж: " + ch.Preset + "\n";
            // result += "ХП: " + ch.HP + ", СИЛ: " + ch.STR + ", СПР: " + ch.DEX + ", ВОЛ: " + ch.WIL + "\n";
            // result += "Броня: " + armorName + ", Зброя: " + weaponName + ", Закляття: " + spellName + "\n";
            // result += "Походження: " + ch.Background + ", Напасть: " + ch.Affliction + ", Статура: " + ch.Stature + "\n";
            // result += "Інвентар: " + inventoryStr + "\n";

            return result;
        }
    }
}



