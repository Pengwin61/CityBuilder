using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Windows
{
    public class WindowsController : Singleton<WindowsController>
    {
        public bool TryGetActiveWindow(out IWindowLogic window)
        {
            window = Instance._openedWindows.LastOrDefault();
            return window != null;
        }

        public static bool IsOpen<Window>()
            where Window : IWindowLogic
        {
            return Instance._openedWindows.Any(window => window is Window);
        }

        public static void Open<Window>()
            where Window : IWindowLogic, new()
        {
            Instance.OpenInternal<Window>();
        }
        public static void Open<Window>(IWindowData data)
            where Window : IWindowLogicWithData, new()
        {
            Instance.OpenInternal<Window>(data);
        }

        public static void Close<Window>()
            where Window : IWindowLogic
        {
            Instance.CloseInternal<Window>();
        }

        public static void OnClose(IWindowLogic windowLogic)
        {
            Instance.OnCloseInternal(windowLogic);
        }

        private readonly List<IWindowLogic> _openedWindows = new List<IWindowLogic>();
        private readonly Dictionary<Type, Stack<IWindowLogic>> _poolLogics = new Dictionary<Type, Stack<IWindowLogic>>();

        private void OpenInternal<Window>()
            where Window : IWindowLogic, new()
        {
            OpeningWindow<Window>().Open();
        }
        private void OpenInternal<Window>(IWindowData data = null)
            where Window : IWindowLogicWithData, new()
        {
            OpeningWindow<Window>().Open(data);
        }

        private Window OpeningWindow<Window>()
            where Window : IWindowLogic, new()
        {
            if (TryGetActiveWindow(out var activeWindow) &&
                activeWindow is Window existedWindow)
            {
                return existedWindow;
            }
            SetVisibleActiveWindow(false);
            var newWindow = GetFromPool<Window>();
            _openedWindows.Add(newWindow);
            return newWindow;
        }

        private void SetVisibleActiveWindow(bool isActive)
        {
            if (TryGetActiveWindow(out var activeWindow))
            {
                activeWindow.SetVisible(isActive);
            }
        }

        private void CloseInternal<Window>()
            where Window : IWindowLogic
        {
            var windowToClose = _openedWindows.FirstOrDefault(window => window is Window);
            if (windowToClose != null)
            {
                windowToClose.Close();
            }
        }

        private void OnCloseInternal(IWindowLogic windowLogic)
        {
            _openedWindows.Remove(windowLogic);
            AddInPool(windowLogic);
            SetVisibleActiveWindow(true);
        }

        private void AddInPool(IWindowLogic window)
        {
            var windowType = window.GetType();
            if (_poolLogics.ContainsKey(windowType) is false)
            {
                _poolLogics.Add(windowType, new Stack<IWindowLogic>());
            }
            _poolLogics[windowType].Push(window);
        }

        private Window GetFromPool<Window>()
            where Window : IWindowLogic, new()
        {
            var windowType = typeof(Window);
            if (_poolLogics.ContainsKey(windowType) is false)
            {
                _poolLogics.Add(windowType, new Stack<IWindowLogic>());
            }
            var existedWindows = _poolLogics[windowType];
            if (existedWindows.Count == 0)
            {
                return new Window();
            }
            return (Window)existedWindows.Pop();
        }
    }
}