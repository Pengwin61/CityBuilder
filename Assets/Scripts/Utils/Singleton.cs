using System;
using System.Collections.Generic;

namespace Utils
{
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        protected static T Instance => _instance ?? (_instance = new T());
    }
}