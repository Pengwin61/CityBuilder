using System.Collections.Generic;

namespace Utils
{
    public static class Extenders
    {
        /// <summary>
        /// Добавить ключ и значение, если такого ключа нет в словаре.
        /// Либо обновить значение, если ключ уже существует
        /// </summary>
        public static void AddOrReplace<Tkey, TValue>(this Dictionary<Tkey, TValue> me, Tkey keyName, TValue newValue)
        {
            if (me.ContainsKey(keyName)) me[keyName] = newValue;
            else me.Add(keyName, newValue);
        }

        /// <summary>
        /// Добавить ключ и его значение только если ранее такого ключа не было
        /// </summary>
        public static void AddIfNotContains<Tkey, TValue>(this Dictionary<Tkey, TValue> me, Tkey keyName, TValue newValue)
        {
            if (!me.ContainsKey(keyName)) me.Add(keyName, newValue);
        }
    }
}