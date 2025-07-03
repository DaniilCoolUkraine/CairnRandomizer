using System.Collections.Generic;
using UnityEngine;

namespace CairnRandomizer.RollData.Traits
{
    [CreateAssetMenu(fileName = nameof(TraitsDataTable), menuName = "RollData/"+nameof(TraitsDataTable))]
    public class TraitsDataTable : ScriptableObject
    {
        public List<string> Physique;
        public List<string> Skin;
        public List<string> Hair;
        public List<string> Face;
        public List<string> Speech;
        public List<string> Clothing;
        public List<string> Virtue;
        public List<string> Vice;
        public List<string> Reputation;
        public List<string> Misfortunes;
    }
}