using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Windows
{
    public class WindowsController : Singleton<WindowsController>
    {
        public static WindowLogic ActiveWindow => Instance._openedWindows.Peek();

        public static bool IsOpen<Window>() where Window : WindowLogic
        {
            return Instance._openedWindows.Any(window => window is Window);
        }

        public static void Open<Window>() where Window : WindowLogic, new()
        {
            Instance.OpenInternal<Window>();
        }

        public static void Open<Window>(IWindowData data) where Window : WindowLogic, new()
        {
            Instance.OpenInternal<Window>(data);
        }

        public static void Close()
        {
            Instance.CloseInternal();
        }

        private readonly Stack<WindowLogic> _openedWindows = new Stack<WindowLogic>();
    
        private void OpenInternal<Window>() where Window : WindowLogic, new()
        {
            OpeningWindow<Window>().Open();
        }

        private void OpenInternal<Window>(IWindowData data) where Window : WindowLogic, new()
        {
            OpeningWindow<Window>().Open(data); 
        }

        private void CloseInternal()
        {
            _openedWindows.Pop().Close(); 
        }

        private Window OpeningWindow<Window>() where Window : WindowLogic, new()
        {
            ActiveWindow.SetVisible(false);
            var newWindow = new Window();
            _openedWindows.Push(newWindow);
            return newWindow;
        }

        private void KeyHandling()
        {
            //back button or esc logic
        }
    }
}