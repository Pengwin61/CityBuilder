using System.Collections.Generic;

namespace Utils
{
    public static class Extenders
    {
        public static void AddOrReplace<Tkey, TValue>(this Dictionary<Tkey, TValue> dict, Tkey keyName, TValue newValue)
        {
            if (dict.ContainsKey(keyName)) dict[keyName] = newValue;
            else dict.Add(keyName, newValue);
        }

        public static void AddIfNotContains<Tkey, TValue>(this Dictionary<Tkey, TValue> dict, Tkey keyName, TValue newValue)
        {
            if (!dict.ContainsKey(keyName)) dict.Add(keyName, newValue);
        }
    }
}