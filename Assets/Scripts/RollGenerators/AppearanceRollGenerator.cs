using CairnRandomizer.General;
using CairnRandomizer.RollData;
using CairnRandomizer.RollData.Names;
using UnityEngine;

namespace CairnRandomizer.RollGenerators
{
    public class AppearanceRollGenerator : IRollGenerator
    {
        public IRollData Roll(RollDataTable dataTable)
        {
            return new TraitRollData(
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
                dataTable.TraitsDataTable.Skin.GetRandomElement());
        }

        private string GetName(RollDataTable dataTable)
        {
            INameDataTable genderName = Random.Range(0, 101) > 50 ? dataTable.MaleNameDataTable : dataTable.FemaleNameDataTable;
            return $"{genderName.Names.GetRandomElement()} {dataTable.SurnameDataTable.Names.GetRandomElement()}";
        }
    }
}