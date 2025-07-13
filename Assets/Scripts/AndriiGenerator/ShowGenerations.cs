using System.Collections.Generic;
using UnityEngine;

namespace CairnRandomizer.AndriiGenerator
{
    public class ShowGenerations : MonoBehaviour
    {
        void Start()
        {
            // Нічого не виконується при запуску
        }

        void Update()
        {
            // Визначаємо стать: якщо Shift натиснутий — Female, інакше — Male
            Gender gender = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? Gender.Female : Gender.Male;

            if (Input.GetKeyDown(KeyCode.Alpha1))
                GenerateAndPrint(CharacterPresetType.Лицар, gender);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                GenerateAndPrint(CharacterPresetType.Воїн, gender);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                GenerateAndPrint(CharacterPresetType.Монах, gender);

            if (Input.GetKeyDown(KeyCode.Alpha4))
                GenerateAndPrint(CharacterPresetType.Слідопит, gender);

            if (Input.GetKeyDown(KeyCode.Alpha5))
                GenerateAndPrint(CharacterPresetType.Маг, gender);

            if (Input.GetKeyDown(KeyCode.Alpha6))
                GenerateAndPrint(CharacterPresetType.Стрілок, gender);

            if (Input.GetKeyDown(KeyCode.Alpha7))
                GenerateAndPrint(CharacterPresetType.Ельф, gender);

            if (Input.GetKeyDown(KeyCode.Alpha8))
                GenerateAndPrint(CharacterPresetType.Рандомний, gender);
        }

        void GenerateAndPrint(CharacterPresetType preset, Gender gender)
        {
            for (int i = 0; i < 3; i++)
            {
                Character ch = new Character();
                ch.GenerateCharacter(preset, gender);
                Debug.Log(FormatCharacter(ch));
            }
        }

        string FormatCharacter(Character ch)
        {
            bool isFemale = ch.Traits.Gender == Gender.Female;
            string pronoun = isFemale ? "вона" : "він";
            string possPronoun = isFemale ? "її" : "його";
            string bePast = isFemale ? "була" : "був";
            string ageWord = isFemale ? "їй" : "йому";
            string dressed = isFemale ? "вдягнена" : "вдягнений";

            int age = UtilityFunctions.Roll3d6() + 20;

            // Заголовок

            string introPhrase = isFemale ? "Її звуть" : "Його звуть";

            string result = string.Format(
                "{0} <b>{1} {2}</b>, {3} {4} років. {5} <b>{6}</b>. Раніше {7} {8} <b>{9}</b>.\n\n",
                introPhrase,
                ch.Traits.FirstName,
                ch.Traits.LastName,
                ageWord,
                age,
                char.ToUpper(pronoun[0]) + pronoun.Substring(1),
                ch.Preset.ToString(),
                pronoun,
                bePast,
                ch.Background
            );


            // Статура та зовнішність
            result += "Має <b>" + ch.Traits.Build.ToLower() + "</b> тіло, ";
            result += "шкіра <b>" + ch.Traits.Skin.ToLower() + "</b>, ";
            result += "волосся <b>" + ch.Traits.Hair.ToLower() + "</b> і ";
            result += "обличчя <b>" + ch.Traits.Face.ToLower() + "</b>.\n";
            result += char.ToUpper(pronoun[0]) + pronoun.Substring(1) + " <b>" + ch.Traits.Speech.ToLower() + "</b> розмовляє і " + dressed + " у <b>" + ch.Traits.Clothing.ToLower() + "</b> одяг.\n\n";

            // Чеснота, вада, репутація, напасть
            string ending = (ch.Traits.Gender == Gender.Female) ? "а" : "ий";
            string virtue = ch.Traits.Virtue.ToLower() + ending;
            string flaw = ch.Traits.Flaw.ToLower() + ending;
            string reputation = ch.Traits.Reputation.ToLower() + ending;
            string affliction = ch.Affliction + ending;

            result += char.ToUpper(pronoun[0]) + pronoun.Substring(1) + " вельми <b>" + virtue + "</b>, а " + possPronoun + " головна вада – <b>" + flaw + "</b>.\n";
            result += "Має репутацію <b>" + reputation + "</b>. " + possPronoun + " напасть – <b>" + affliction + "</b>.\n\n";


            // Характеристики
            result += "<color=#e06666><b>" + ch.HP + " ПЗ | " + ch.STR + " СИЛ | " + ch.DEX + " СПР | " + ch.WIL + " ВОЛ</b></color>\n\n";

            // Інвентар
            result += "Майно:\n";
            foreach (var item in ch.Inventory)
            {
                result += "• " + item.Name + "\n";
            }

            if (ch.Armor != null && !ContainsItem(ch.Inventory, ch.Armor.Name))
                result += "• <b>Броня: " + ch.Armor.Name + " (" + ch.Armor.ArmorAmount + " броні)</b>\n";

            if (ch.Weapon != null && !ContainsItem(ch.Inventory, ch.Weapon.Name))
                result += "• <b>Зброя: " + ch.Weapon.Name + "</b>\n";

            if (ch.Spell != null && !ContainsItem(ch.Inventory, ch.Spell.Name))
                result += "• <b>Закляття: " + ch.Spell.Name + "</b>\n";

            return result;
        }


        bool ContainsItem(List<Item> inventory, string name)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Name == name)
                    return true;
            }
            return false;
        }
    }
}

