using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Windows
{
    public class WindowsController : Singleton<WindowsController>
    {
        public static WindowLogic ActiveWindow => Instance._openedWindows.LastOrDefault();

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

        public static void OnClose(WindowLogic windowLogic)
        {
            Instance.OnCloseInternal(windowLogic);
        }

        private readonly List<WindowLogic> _openedWindows = new List<WindowLogic>();

        private void OpenInternal<Window>() where Window : WindowLogic, new()
        {
            OpeningWindow<Window>().Open();
        }
        private void OpenInternal<Window>(IWindowData data = null) where Window : WindowLogic, new()
        {
            OpeningWindow<Window>().Open(data);
        }

        private void OnCloseInternal(WindowLogic windowLogic)
        {
            _openedWindows.Remove(windowLogic);
            SetActiveWindowVisible(true);
        }

        private Window OpeningWindow<Window>() where Window : WindowLogic, new()
        {
            SetActiveWindowVisible(false);
            var newWindow = new Window();
            _openedWindows.Add(newWindow);
            newWindow.SetupViewObj();
            return newWindow;
        }

        private void SetActiveWindowVisible(bool isActive)
        {
            if (ActiveWindow == null)
            {
                return;
            }
            ActiveWindow.SetVisible(isActive);
        }
    }
}