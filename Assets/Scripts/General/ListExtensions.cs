using System.Collections.Generic;
using UnityEngine;

namespace CairnRandomizer.General
{
    public static class ListExtensions
    {
        public static T GetRandomElement<T>(this List<T> list)
        {
            var random = Random.Range(0, list.Count);
            return list[random];
        }
    }
}