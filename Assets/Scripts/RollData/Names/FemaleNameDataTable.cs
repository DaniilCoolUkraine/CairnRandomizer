using System.Collections.Generic;
using UnityEngine;

namespace CairnRandomizer.RollData.Names
{
    [CreateAssetMenu(fileName = nameof(FemaleNameDataTable), menuName = "RollData/"+nameof(FemaleNameDataTable))]
    public sealed class FemaleNameDataTable : ScriptableObject, INameDataTable 
    {
        [field:SerializeField] public List<string> Names { get; private set; }
    }
}