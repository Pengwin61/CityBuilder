using System;
using System.Collections.Generic;
using Utils;

namespace Pool
{
    public class PoolLogics<LogicType> : Singleton<PoolLogics<LogicType>>
    {
        public static void AddInPool(LogicType window)
        {
            Instance.AddInPoolInternal(window);
        }

        public static Window GetFromPool<Window>()
            where Window : LogicType, new()
        {
            return Instance.GetFromPoolInternal<Window>();
        }

        private readonly Dictionary<Type, Stack<LogicType>> _windowLogics = new Dictionary<Type, Stack<LogicType>>();

        private void AddInPoolInternal(LogicType window)
        {
            var windowType = window.GetType();
            if (_windowLogics.ContainsKey(windowType) is false)
            {
                _windowLogics.Add(windowType, new Stack<LogicType>());
            }
            _windowLogics[windowType].Push(window);
        }

        private Window GetFromPoolInternal<Window>()
            where Window : LogicType, new()
        {
            var windowType = typeof(Window);
            if (_windowLogics.ContainsKey(windowType) is false)
            {
                _windowLogics.Add(windowType, new Stack<LogicType>());
            }
            var existedWindows = _windowLogics[windowType];
            if (existedWindows.Count == 0)
            {
                return new Window();
            }
            return (Window)existedWindows.Pop();
        }
    }
}