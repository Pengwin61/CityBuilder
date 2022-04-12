using System;
using System.Collections.Generic;

namespace Utils
{
    public interface ISingleton
    {
        public bool IsExist { get; }
        public ISingleton Init();
    }

    public class SingletonesHandler
    {
        private Dictionary<Type, ISingleton> _instances = new Dictionary<Type, ISingleton>();

        public T Get<T>() where T : class, ISingleton, new()
        {
            var instanceType = typeof(T);

            if (_instances.ContainsKey(instanceType) is false ||
                _instances[instanceType].IsExist is false)
            {
                T newInstance = new T();
                newInstance.Init();
                Set(newInstance);
            }

            return (T)_instances[instanceType];
        }

        public void Set<T>(T newInstance) where T : class, ISingleton
        {
            _instances.AddOrReplace(typeof(T), newInstance);
        }
    }
}