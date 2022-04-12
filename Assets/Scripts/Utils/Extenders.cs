using System.Collections.Generic;

namespace Utils
{
    public static class Extenders
    {
        /// <summary>
        /// �������� ���� � ��������, ���� ������ ����� ��� � �������.
        /// ���� �������� ��������, ���� ���� ��� ����������
        /// </summary>
        public static void AddOrReplace<Tkey, TValue>(this Dictionary<Tkey, TValue> me, Tkey keyName, TValue newValue)
        {
            if (me.ContainsKey(keyName)) me[keyName] = newValue;
            else me.Add(keyName, newValue);
        }

        /// <summary>
        /// �������� ���� � ��� �������� ������ ���� ����� ������ ����� �� ����
        /// </summary>
        public static void AddIfNotContains<Tkey, TValue>(this Dictionary<Tkey, TValue> me, Tkey keyName, TValue newValue)
        {
            if (!me.ContainsKey(keyName)) me.Add(keyName, newValue);
        }
    }
}