using CairnRandomizer.General;
using CairnRandomizer.RollData;
using CairnRandomizer.RollData.Names;
using CairnRandomizer.RollGenerators.GeneratorData;
using SimpleEventBus.SimpleEventBus.Runtime;
using UnityEngine;

namespace CairnRandomizer.RollGenerators
{
    public class AppearanceRollGenerator : IRollGenerator
    {
        public IRollData Roll(RollDataTable dataTable)
        {
            var roll = new AppearanceRollData(
                GetName(dataTable), 
                dataTable.TraitsDataTable.Backgrounds.GetRandomElement(),
                dataTable.TraitsDataTable.Misfortunes.GetRandomElement(),
                dataTable.TraitsDataTable.Reputation.GetRandomElement(),
                dataTable.TraitsDataTable.Vice.GetRandomElement(), 
                dataTable.TraitsDataTable.Virtue.GetRandomElement(),
                dataTable.TraitsDataTable.Clothing.GetRandomElement(),
                dataTable.TraitsDataTable.Speech.GetRandomElement(), 
                dataTable.TraitsDataTable.Face.GetRandomElement(),
                dataTable.TraitsDataTable.Hair.GetRandomElement(), 
                dataTable.TraitsDataTable.Skin.GetRandomElement(),
                GetAge(),
                dataTable.TraitsDataTable.Physique.GetRandomElement(),
                GetSurname(dataTable));

            GlobalEvents.Publish(new AppearanceRollCompleted(roll.Background, roll.Misfortune));

            return roll;
        }

        private string GetName(RollDataTable dataTable)
        {
            INameDataTable genderName = Random.Range(0, 101) > 50 ? dataTable.MaleNameDataTable : dataTable.FemaleNameDataTable;
            return $"{genderName.Names.GetRandomElement()}";
        }
        
        private string GetSurname(RollDataTable dataTable)
        {
            return dataTable.SurnameDataTable.Names.GetRandomElement();
        }

        private int GetAge()
        {
            return Random.Range(0, 21) + Random.Range(0, 21) + 10;
        }
    }
}