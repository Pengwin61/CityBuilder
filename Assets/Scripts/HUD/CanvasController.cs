using Pool;
using Utils;

namespace HUD
{
    public class CanvasController : Singleton<CanvasController>, IPoolCreator
    {
        private const string PATH = "HUD";

        private CanvasView _canvasView;

        public string Path => PATH;

        public CanvasController()
        {
            CreateObj();
        }


        public void CreateObj()
        {
            _canvasView = PrefabLoader.GetObject<CanvasView>(Path);
        }
    }
}