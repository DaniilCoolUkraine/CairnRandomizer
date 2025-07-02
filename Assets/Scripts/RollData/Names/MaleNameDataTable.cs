using System.Collections.Generic;
using UnityEngine;

namespace CairnRandomizer.RollData.Names
{
    [CreateAssetMenu(fileName = nameof(MaleNameDataTable), menuName = "RollData/"+nameof(MaleNameDataTable))]
    public sealed class MaleNameDataTable : ScriptableObject, INameDataTable 
    {
        [field:SerializeField] public List<string> Names { get; private set; }
    }
}