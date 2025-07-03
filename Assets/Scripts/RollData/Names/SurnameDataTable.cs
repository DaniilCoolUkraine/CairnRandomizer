using System.Collections.Generic;
using UnityEngine;

namespace CairnRandomizer.RollData.Names
{
    [CreateAssetMenu(fileName = nameof(SurnameDataTable), menuName = "RollData/Names/"+nameof(SurnameDataTable))]
    public class SurnameDataTable : ScriptableObject, INameDataTable 
    {
        [field:SerializeField] public List<string> Names { get; private set; }
    }
}