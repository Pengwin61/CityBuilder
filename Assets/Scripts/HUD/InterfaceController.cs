using Utils;
using Windows;

namespace HUD
{
    public class InterfaceController : Singleton<InterfaceController>
    {
        private const string PATH = "HUD";

        private readonly InterfaceView _hudView;

        public static void ShowWindow(IWindowView windowView)
        {
            var hud = Instance._hudView;
            if (hud == null)
            {
                return;
            }
            hud.ShowWindow(windowView);
        }

        public InterfaceController()
        {
            PrefabLoader.TryGetObject(PATH, out _hudView);
        }
    }
}