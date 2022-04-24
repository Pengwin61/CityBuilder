using Utils;

namespace HUD
{
    public class InterfaceController : Singleton<InterfaceController>
    {
        private const string PATH = "HUD";

        private InterfaceView _hudView;

        public static void ShowWindow(Windows.WindowView windowView)
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