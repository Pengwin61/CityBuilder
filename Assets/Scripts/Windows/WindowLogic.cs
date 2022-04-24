using Pool;

namespace Windows
{
    public interface IWindowData { }

    public abstract class WindowLogic : IObjectCreator
    {
        protected WindowView windowView;

        public virtual string Path { get; }

        public virtual void Open(IWindowData data)
        {
            SetVisible(true);
        }

        public virtual void Close()
        {
            ObjectPooler.PushBack(windowView.gameObject);
            WindowsController.OnClose(this);
        }

        public virtual void SetVisible(bool isActive)
        {
            windowView.SetVisible(isActive);
        }

        public virtual void BackBehaviour()
        {
            Close();
        }

        public void CreateObj()
        {
            windowView = ObjectPooler.GetObject(Path).GetComponent<WindowView>();
            windowView.SetLogic(this);
            HUD.InterfaceController.ShowWindow(windowView);
        }
    }
}