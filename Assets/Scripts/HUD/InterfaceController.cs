using Pool;
using Utils;

namespace HUD
{
    public class InterfaceController : Singleton<InterfaceController>
    {
        private const string PATH = "HUD";

        private InterfaceView _canvasView;

        public static void ShowWindow(Windows.WindowView windowView)
        {
            Instance._canvasView.ShowWindow(windowView);
        }

        public InterfaceController()
        {
            _canvasView = PrefabLoader.GetObject<InterfaceView>(PATH);
        }
    }
}