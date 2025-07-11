using System;
using System.Collections.Generic;
using System.Linq;
using CairnRandomizer.General;
using CairnRandomizer.RollData;
using CairnRandomizer.RollData.Equipment;
using CairnRandomizer.RollGenerators.GeneratorData;
using SimpleEventBus.SimpleEventBus.Runtime;
using Random = UnityEngine.Random;

namespace CairnRandomizer.RollGenerators
{
    public class EquipmentRollGenerator : IRollGenerator, IDisposable
    {
        private string _background;
        private string _misfortune;

        private List<EquipmentData> _items;

        public EquipmentRollGenerator()
        {
            GlobalEvents.AddListener<AppearanceRollCompleted>(OnAppearanceRollCompleted);
            _items = new List<EquipmentData>();
        }

        public IRollData Roll(RollDataTable dataTable)
        {
            _items.Clear();

            // add torch and rations
            _items.Add(dataTable.EquipmentDataTable.EquipmentList.FirstOrDefault(e => e.Id == 85));
            _items.Add(dataTable.EquipmentDataTable.EquipmentList.FirstOrDefault(e => e.Id == 86));

            // roll for armor
            _items.Add(RollForArmor(dataTable.EquipmentDataTable.EquipmentList));

            // roll for shield and helmet
            _items.Add(RollForArmor(dataTable.EquipmentDataTable.EquipmentList, true));

            // roll for weapon
            _items.Add(RollForWeapon(dataTable.EquipmentDataTable.EquipmentList));

            if (string.IsNullOrWhiteSpace(_misfortune) || string.IsNullOrWhiteSpace(_background))
            {
                // roll for gear
                _items.Add(dataTable.EquipmentDataTable.EquipmentList
                    .Where(e => e is GearData)
                    .ToList().GetRandomElement());

                // roll for tool
                _items.Add(dataTable.EquipmentDataTable.EquipmentList
                    .Where(e => e is ToolData)
                    .ToList().GetRandomElement());

                // roll for trinkets
                _items.Add(dataTable.EquipmentDataTable.EquipmentList
                    .Where(e => e is TrinketsData)
                    .ToList().GetRandomElement());
            }
            else
            {
                var itemsId = dataTable.TraitToEquipment.TraitToItemIds.FirstOrDefault(t => t.Trait == _misfortune).ItemIds;
                var item = dataTable.EquipmentDataTable.EquipmentList.FirstOrDefault(i => i.Id == itemsId.GetRandomElement());

                _items.Add(item);

                itemsId = dataTable.TraitToEquipment.TraitToItemIds.FirstOrDefault(t => t.Trait == _background).ItemIds;

                foreach (int id in itemsId)
                {
                    item = dataTable.EquipmentDataTable.EquipmentList.FirstOrDefault(i => i.Id == id);
                    _items.Add(item);
                }
            }

            // TODO roll for bonus item


            return new EquipmentRollData(_items);
        }

        private EquipmentData RollForArmor(List<EquipmentData> equipment, bool secondary = false)
        {
            var matchingItems = equipment.Where(e => e is ArmorData armorData && armorData.IsSecondary == secondary)
                .OrderBy(d => ((ArmorData)d).Armor)
                .GroupBy(d => ((ArmorData)d).Tier);

            var roll = Random.Range(1, 21);

            if (!secondary)
            {
                if (roll <= 3)
                    return null;

                if (roll <= 14)
                    return matchingItems.FirstOrDefault(a => a.Key == 2).ToList().GetRandomElement();

                if (roll <= 19)
                    return matchingItems.FirstOrDefault(a => a.Key == 3).ToList().GetRandomElement();

                return matchingItems.FirstOrDefault(a => a.Key == 4).ToList().GetRandomElement();
            }

            if (roll <= 13)
                return null;

            if (roll <= 16)
                return matchingItems.FirstOrDefault(a => a.Key == 2).ToList().GetRandomElement();

            if (roll <= 19)
                return matchingItems.FirstOrDefault(a => a.Key == 3).ToList().GetRandomElement();

            return matchingItems.FirstOrDefault(a => a.Key == 4).ToList().GetRandomElement();
        }

        private EquipmentData RollForWeapon(List<EquipmentData> equipment)
        {
            var matchingItems = equipment.Where(e => e is WeaponData)
                .GroupBy(d => ((WeaponData)d).Tier);

            var roll = Random.Range(1, 21);

            if (roll <= 5)
                return matchingItems.FirstOrDefault(a => a.Key == 1).ToList().GetRandomElement();

            if (roll <= 13)
                return matchingItems.FirstOrDefault(a => a.Key == 2).ToList().GetRandomElement();

            if (roll <= 18)
                return matchingItems.FirstOrDefault(a => a.Key == 3).ToList().GetRandomElement();

            return matchingItems.FirstOrDefault(a => a.Key == 4).ToList().GetRandomElement();
        }
        
        public void Dispose()
        {
            GlobalEvents.RemoveListener<AppearanceRollCompleted>(OnAppearanceRollCompleted);
        }

        private void OnAppearanceRollCompleted(AppearanceRollCompleted ev)
        {
            _background = ev.Background;
            _misfortune = ev.Misfortune;
        }
    }
}