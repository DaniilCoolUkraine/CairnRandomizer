using System.Collections.Generic;

namespace CairnRandomizer.AndriiGenerator
{
    public static class DataLibrary
    {
        private static List<Affliction> afflictions = null;
        private static List<Background> backgrounds = null;
        private static List<Armor> armors = null;
        private static List<Weapon> weapons = null;
        private static List<Spell> spells = null;
        private static List<Item> genericItems = null;

        public static CharacterPreset GetPreset(CharacterPresetType type)
        {
            // Лицар
            if (type == CharacterPresetType.Лицар)
            {
                return new CharacterPreset
                {
                    AttributeOrder = new List<int> { 0, 1, 3, 2 },
                    ArmorAmount = 2,
                    WeaponType = Weapon.WeaponType.Ближня,
                    TypeSpellProbability = new List<int> { 100, 0, 0, 0 }
                };
            }

            // Воїн
            if (type == CharacterPresetType.Воїн)
            {
                return new CharacterPreset
                {
                    AttributeOrder = new List<int> { 1, 0, 2, 3 },
                    ArmorAmount = 1,
                    WeaponType = Weapon.WeaponType.Ближня,
                    TypeSpellProbability = new List<int> { 100, 0, 0, 0 }
                };
            }

            // Монах
            if (type == CharacterPresetType.Монах)
            {
                return new CharacterPreset
                {
                    AttributeOrder = new List<int> { 1, 2, 3, 0 },
                    ArmorAmount = 1,
                    WeaponType = Weapon.WeaponType.Немає,
                    TypeSpellProbability = new List<int> { 0, 67, 33, 0 }
                };
            }

            // Слідопит
            if (type == CharacterPresetType.Слідопит)
            {
                return new CharacterPreset
                {
                    AttributeOrder = new List<int> { 2, 1, 0, 3 },
                    ArmorAmount = 1,
                    WeaponType = Weapon.WeaponType.Ближня,
                    TypeSpellProbability = new List<int> { 100, 0, 0, 0 }
                };
            }

            // Маг
            if (type == CharacterPresetType.Маг)
            {
                return new CharacterPreset
                {
                    AttributeOrder = new List<int> { 2, 3, 1, 0 },
                    ArmorAmount = 0,
                    WeaponType = Weapon.WeaponType.Немає,
                    TypeSpellProbability = new List<int> { 0, 20, 60, 20 }
                };
            }

            // Стрілок
            if (type == CharacterPresetType.Стрілок)
            {
                return new CharacterPreset
                {
                    AttributeOrder = new List<int> { 1, 2, 0, 3 },
                    ArmorAmount = 0,
                    WeaponType = Weapon.WeaponType.Дальня,
                    TypeSpellProbability = new List<int> { 100, 0, 0, 0 }
                };
            }

            // Ельф
            if (type == CharacterPresetType.Ельф)
            {
                return new CharacterPreset
                {
                    AttributeOrder = new List<int> { 2, 3, 0, 1 },
                    ArmorAmount = 0,
                    WeaponType = Weapon.WeaponType.Дальня,
                    TypeSpellProbability = new List<int> { 0, 0, 33, 67 }
                };
            }

            // Пресет за замовчуванням (Рандомний або невизначений)
            return new CharacterPreset
            {
                AttributeOrder = new List<int> { 0, 1, 2, 3 },
                ArmorAmount = 0,
                WeaponType = Weapon.WeaponType.Немає,
                TypeSpellProbability = new List<int> { 25, 25, 25, 25 }
            };
        }

        private static void InitAfflictions()
        {
            afflictions = new List<Affliction>();

            afflictions.Add(new Affliction("Покинутий"));
            afflictions.Add(new Affliction("Залежність"));
            afflictions.Add(new Affliction("Шантажований"));
            afflictions.Add(new Affliction("Засуджений"));
            afflictions.Add(new Affliction("Проклятий"));
            afflictions.Add(new Affliction("Ошуканий"));
            afflictions.Add(new Affliction("Розжалуваний"));
            afflictions.Add(new Affliction("Дискредитований"));
            afflictions.Add(new Affliction("Від нього відреклися"));
            afflictions.Add(new Affliction("Вигнанець"));
        }
        private static void InitBackgrounds()
        {
            backgrounds = new List<Background>();

            backgrounds.Add(new Background("Алхімік"));
            backgrounds.Add(new Background("Коваль"));
            backgrounds.Add(new Background("М’ясник"));
            backgrounds.Add(new Background("Грабіжник"));
            backgrounds.Add(new Background("Столяр"));
            backgrounds.Add(new Background("Клірик"));
            backgrounds.Add(new Background("Шулер"));
            backgrounds.Add(new Background("Могильник"));
            backgrounds.Add(new Background("Травник"));
            backgrounds.Add(new Background("Мисливець"));
            backgrounds.Add(new Background("Чарівник"));
            backgrounds.Add(new Background("Найманець"));
            backgrounds.Add(new Background("Торговець"));
            backgrounds.Add(new Background("Шахтар"));
            backgrounds.Add(new Background("Бандит"));
            backgrounds.Add(new Background("Артист"));
            backgrounds.Add(new Background("Кишеньковий злодій"));
            backgrounds.Add(new Background("Контрабандист"));
            backgrounds.Add(new Background("Слуга"));
            backgrounds.Add(new Background("Слідопит"));
        }
        private static void InitArmors()
        {
            armors = new List<Armor>();
            armors.Add(new Armor("Немає", 0));
            armors.Add(new Armor("Бригандина", 1));
            armors.Add(new Armor("Кольчуга", 2));
            armors.Add(new Armor("Латні обладунки", 3));
        }
        private static void InitWeapons()
        {
            weapons = new List<Weapon>();

            // БЛИЖНЯ — Слабка
            weapons.Add(new Weapon("Кинжал", Weapon.WeaponType.Ближня, Weapon.Power.Слабка));
            weapons.Add(new Weapon("Палиця", Weapon.WeaponType.Ближня, Weapon.Power.Слабка));
            weapons.Add(new Weapon("Посох", Weapon.WeaponType.Ближня, Weapon.Power.Слабка));

            // БЛИЖНЯ — Середня
            weapons.Add(new Weapon("Короткий меч", Weapon.WeaponType.Ближня, Weapon.Power.Середня));
            weapons.Add(new Weapon("Короткий спис", Weapon.WeaponType.Ближня, Weapon.Power.Середня));

            // БЛИЖНЯ — Сильна
            weapons.Add(new Weapon("Меч", Weapon.WeaponType.Ближня, Weapon.Power.Сильна));
            weapons.Add(new Weapon("Булава", Weapon.WeaponType.Ближня, Weapon.Power.Сильна));
            weapons.Add(new Weapon("Сокира", Weapon.WeaponType.Ближня, Weapon.Power.Сильна));
            weapons.Add(new Weapon("Спис", Weapon.WeaponType.Ближня, Weapon.Power.Сильна));

            // БЛИЖНЯ — Імба
            weapons.Add(new Weapon("Алебарда", Weapon.WeaponType.Ближня, Weapon.Power.Імба));
            weapons.Add(new Weapon("Бойовий молот", Weapon.WeaponType.Ближня, Weapon.Power.Імба));
            weapons.Add(new Weapon("Бойова сокира", Weapon.WeaponType.Ближня, Weapon.Power.Імба));

            // ДАЛЬНЯ — Слабка
            weapons.Add(new Weapon("Праща", Weapon.WeaponType.Дальня, Weapon.Power.Слабка));

            // ДАЛЬНЯ — Середня
            weapons.Add(new Weapon("Короткий лук", Weapon.WeaponType.Дальня, Weapon.Power.Середня));

            // ДАЛЬНЯ — Сильна
            weapons.Add(new Weapon("Довгий лук", Weapon.WeaponType.Дальня, Weapon.Power.Сильна));
            weapons.Add(new Weapon("Арбалет", Weapon.WeaponType.Дальня, Weapon.Power.Сильна));

            // ДАЛЬНЯ — Імба
            weapons.Add(new Weapon("Ручний багатозарядний арбалет", Weapon.WeaponType.Дальня, Weapon.Power.Імба));
        }
        private static void InitSpells()
        {
            spells = new List<Spell>();

            // 🔴 Бойові
            spells.Add(new Spell("Звіряча подоба", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Контроль рослин", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Зцілення ран", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Землетрус", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Стихійна стіна", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Багаторукість", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Яма", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Підняти мертвих", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Рій", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Інструмент", Spell.SpellType.Бойовий));
            spells.Add(new Spell("Телепортація", Spell.SpellType.Бойовий));

            // 🟡 Комбіновані (частково — 30+ штук, вибрані найочевидніші)
            spells.Add(new Spell("Оживлення предметів", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Людиноподібність", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Астральна в’язниця", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Привалити", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Обмін тілами", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Пелена", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Прискорення", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Крижаний дотик", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Подоба предмету", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Форма слизу", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Сон", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Викликати куб", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Телекінез", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Божевілля", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Керування стихіями", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Павутиння", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Зміна тяжіння", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Брама", Spell.SpellType.Комбінований));
            spells.Add(new Spell("Послаблення магії", Spell.SpellType.Комбінований));

            // 🟢 Сапорт (витягнуто з другого зображення — лише частина)
            spells.Add(new Spell("Чарівне око", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Базікання", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Контроль погоди", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Гіпноз", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Виявити магію", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Освітлення", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Маскування", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Підглядання", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Равликовий лицар", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Сортування", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Ненависть", Spell.SpellType.Сапорт));
            spells.Add(new Spell("Видовище", Spell.SpellType.Сапорт));
        }
        private static void InitGenericItems()
        {
            genericItems = new List<Item>();

            // Експедиційне спорядження
            genericItems.Add(new Item { Name = "Антитоксин" });
            genericItems.Add(new Item { Name = "Шків" });
            genericItems.Add(new Item { Name = "Велика пастка" });
            genericItems.Add(new Item { Name = "Ланцюг (10 футів)" });
            genericItems.Add(new Item { Name = "Повітряний міхур" });
            genericItems.Add(new Item { Name = "Мотузка (25 футів)" });
            genericItems.Add(new Item { Name = "Візок" });
            genericItems.Add(new Item { Name = "Абордажний гак" });
            genericItems.Add(new Item { Name = "Відмички" });
            genericItems.Add(new Item { Name = "Тоя (Вовкобій)" });
            genericItems.Add(new Item { Name = "Вогняне масло" });
            genericItems.Add(new Item { Name = "Кайданки" });
            genericItems.Add(new Item { Name = "Кирка" });
            genericItems.Add(new Item { Name = "Жердина (10 футів)" });
            genericItems.Add(new Item { Name = "Великий мішок" });
            genericItems.Add(new Item { Name = "Репелент" });
            genericItems.Add(new Item { Name = "Талісман від духів" });
            genericItems.Add(new Item { Name = "Магічна лоза" });
            genericItems.Add(new Item { Name = "Підзорна труба" });
            genericItems.Add(new Item { Name = "Трут" });

            // Інструменти
            genericItems.Add(new Item { Name = "Крейда" });
            genericItems.Add(new Item { Name = "Герметик" });
            genericItems.Add(new Item { Name = "Лопата" });
            genericItems.Add(new Item { Name = "Міхи" });
            genericItems.Add(new Item { Name = "Жир" });
            genericItems.Add(new Item { Name = "Пила" });
            genericItems.Add(new Item { Name = "Відро" });
            genericItems.Add(new Item { Name = "Кальтропи" });
            genericItems.Add(new Item { Name = "Зубило" });
            genericItems.Add(new Item { Name = "Ручний дриль" });
            genericItems.Add(new Item { Name = "Вудочка" });
            genericItems.Add(new Item { Name = "Молоток" });
            genericItems.Add(new Item { Name = "Клей" });
            genericItems.Add(new Item { Name = "Каструлі" });
            genericItems.Add(new Item { Name = "Пісочний годинник" });
            genericItems.Add(new Item { Name = "Сітка" });
            genericItems.Add(new Item { Name = "Кліщі" });
            genericItems.Add(new Item { Name = "Лом" });
            genericItems.Add(new Item { Name = "Напилок по металу" });
            genericItems.Add(new Item { Name = "Цвяхи" });

            // Дрібнички
            genericItems.Add(new Item { Name = "Пахощі" });
            genericItems.Add(new Item { Name = "Губка" });
            genericItems.Add(new Item { Name = "Лінза" });
            genericItems.Add(new Item { Name = "Парфуми" });
            genericItems.Add(new Item { Name = "Горн" });
            genericItems.Add(new Item { Name = "Пляшка" });
            genericItems.Add(new Item { Name = "Мило" });
            genericItems.Add(new Item { Name = "Інструмент" });
            genericItems.Add(new Item { Name = "Горщик дьогтю" });
            genericItems.Add(new Item { Name = "Шпагат" });
            genericItems.Add(new Item { Name = "Камені-фальшивки" });
            genericItems.Add(new Item { Name = "Пакет солі" });
            genericItems.Add(new Item { Name = "Колода карт" });
            genericItems.Add(new Item { Name = "Набір кубиків" });
            genericItems.Add(new Item { Name = "Мармурові кульки" });
            genericItems.Add(new Item { Name = "Грим" });
            genericItems.Add(new Item { Name = "Свисток" });
            genericItems.Add(new Item { Name = "Дзеркальце" });
            genericItems.Add(new Item { Name = "Перо і чорнило" });
            genericItems.Add(new Item { Name = "Дзвоник" });
        }

        public static Weapon GetRandomWeapon(Weapon.WeaponType type)
        {
            if (weapons == null)
                InitWeapons();

            int roll = UnityEngine.Random.Range(0, 100);
            Weapon.Power power;

            if (roll < 25) power = Weapon.Power.Слабка;
            else if (roll < 65) power = Weapon.Power.Середня;
            else if (roll < 90) power = Weapon.Power.Сильна;
            else power = Weapon.Power.Імба;

            List<Weapon> pool = new List<Weapon>();
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].Type == type && weapons[i].PowerLevel == power)
                    pool.Add(weapons[i]);
            }

            if (pool.Count == 0)
                return new Weapon("Кулаки", Weapon.WeaponType.Немає, Weapon.Power.Слабка);

            int index = UnityEngine.Random.Range(0, pool.Count);
            return pool[index];
        }
        public static Spell GetRandomSpell(Spell.SpellType type)
        {
            if (spells == null)
                InitSpells();

            List<Spell> pool = new List<Spell>();

            for (int i = 0; i < spells.Count; i++)
            {
                if (spells[i].Type == type)
                    pool.Add(spells[i]);
            }

            if (pool.Count == 0)
                return new Spell("Немає", Spell.SpellType.Немає);

            int index = UnityEngine.Random.Range(0, pool.Count);
            return pool[index];
        }
        public static Armor GetArmorByAmount(int amount)
        {
            if (armors == null)
                InitArmors();

            for (int i = 0; i < armors.Count; i++)
            {
                if (armors[i].ArmorAmount == amount)
                    return armors[i];
            }

            // Якщо не знайдено — повертаємо "Немає"
            return armors[0];
        }
        public static Armor GetRandomArmor()
        {
            if (armors == null)
                InitArmors();

            int index = UnityEngine.Random.Range(0, armors.Count);
            return armors[index];
        }
        public static Background GetRandomBackground()
        {
            if (backgrounds == null)
                InitBackgrounds();

            int index = UnityEngine.Random.Range(0, backgrounds.Count);
            return backgrounds[index];
        }
        public static Affliction GetRandomAffliction()
        {
            if (afflictions == null)
                InitAfflictions();

            int index = UnityEngine.Random.Range(0, afflictions.Count);
            return afflictions[index];
        }

        public static List<Item> GetItemsFromAffliction(Affliction aff)
        {
            List<Item> list = new List<Item>();

            if (aff == null) return list;

            string name = aff.Name;
            Item item = new Item();

            // Проста прив'язка через текст
            if (name == "Покинутий") item.Name = "Камінь пам’яті";
            else if (name == "Залежність") item.Name = "Флакон із залишками речовини";
            else if (name == "Шантажований") item.Name = "Запечатаний лист";
            else if (name == "Засуджений") item.Name = "Клеймо ганьби";
            else if (name == "Проклятий") item.Name = "Талісман прокляття";
            else if (name == "Ошуканий") item.Name = "Фальшивий контракт";
            else if (name == "Розжалуваний") item.Name = "Зіпсована відзнака";
            else if (name == "Дискредитований") item.Name = "Компрометуючі документи";
            else if (name == "Від нього відреклися") item.Name = "Обручка зламаних обітниць";
            else if (name == "Вигнанець") item.Name = "Потертий плащ мандрівника";
            else item = null;

            if (item != null)
                list.Add(item);

            return list;
        }
        public static List<Item> GetItemsFromBackground(Background bg)
        {
            List<Item> list = new List<Item>();
            if (bg == null) return list;

            string name = bg.Name;
            Item item1 = new Item();
            Item item2 = new Item();

            if (name == "Алхімік") { item1.Name = "Алхімічний набір"; item2.Name = "Колба з ртуттю"; }
            else if (name == "Коваль") { item1.Name = "Молот"; item2.Name = "Залізний злиток"; }
            else if (name == "М’ясник") { item1.Name = "Обвалювальний ніж"; item2.Name = "Фартух у крові"; }
            else if (name == "Грабіжник") { item1.Name = "Мішок із золотом"; item2.Name = "Капюшон грабіжника"; }
            else if (name == "Столяр") { item1.Name = "Рубанок"; item2.Name = "Ящик із цвяхами"; }
            else if (name == "Клірик") { item1.Name = "Свята книга"; item2.Name = "Фляга освяченої води"; }
            else if (name == "Шулер") { item1.Name = "Карткова колода"; item2.Name = "Фішки для гри"; }
            else if (name == "Могильник") { item1.Name = "Лопата"; item2.Name = "Ключ від склепу"; }
            else if (name == "Травник") { item1.Name = "Травник"; item2.Name = "Сумка з рослинами"; }
            else if (name == "Мисливець") { item1.Name = "Пастка"; item2.Name = "Спис мисливця"; }
            else if (name == "Чарівник") { item1.Name = "Жезл"; item2.Name = "Магічна книга"; }
            else if (name == "Найманець") { item1.Name = "Контракт убивці"; item2.Name = "Зношений меч"; }
            else if (name == "Торговець") { item1.Name = "Крамниця на колесах"; item2.Name = "Мішечок монет"; }
            else if (name == "Шахтар") { item1.Name = "Кирка"; item2.Name = "Шолом із ліхтарем"; }
            else if (name == "Бандит") { item1.Name = "Брудна пов'язка"; item2.Name = "Ніж у чоботі"; }
            else if (name == "Артист") { item1.Name = "Костюм"; item2.Name = "Маска"; }
            else if (name == "Кишеньковий злодій") { item1.Name = "Гачок злодія"; item2.Name = "Мішечок з дріб’язком"; }
            else if (name == "Контрабандист") { item1.Name = "Фальшиві документи"; item2.Name = "Тайник"; }
            else if (name == "Слуга") { item1.Name = "Срібна ложка"; item2.Name = "Одяг прислуги"; }
            else if (name == "Слідопит") { item1.Name = "Карта місцевості"; item2.Name = "Комплект виживання"; }
            else { return list; }

            list.Add(item1);
            list.Add(item2);
            return list;
        }
        public static List<Item> GetRandomItems(int count)
        {
            if (genericItems == null)
                InitGenericItems();

            List<Item> result = new List<Item>();
            int size = genericItems.Count;

            for (int i = 0; i < count; i++)
            {
                int index = UnityEngine.Random.Range(0, size);
                result.Add(genericItems[index]);
            }

            return result;
        }
    }
}

