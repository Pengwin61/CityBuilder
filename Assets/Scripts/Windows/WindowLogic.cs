namespace Windows
{
    public interface IWindowData { }

    public abstract class WindowLogic
    {
        protected WindowView windowView;

        public abstract string Path { get; }

        public virtual void Open()
        {
            SetVisible(true);
        }
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
            if (windowView == null)
            {
                return;
            }
            windowView.SetVisible(isActive);
        }

        public virtual void BackBehaviour()
        {
            Close();
        }

        public void SetupViewObj()
        {
            if (ObjectPooler.TryGetObject(Path, out var windowObj) is false)
            {
                return;
            }
            windowView = windowObj.GetComponent<WindowView>();
            windowView.SetLogic(this);
            HUD.InterfaceController.ShowWindow(windowView);
        }

        protected bool TryGetWindowView<T>(out T windowView)
        {
            if (this.windowView != null && this.windowView is T view)
            {
                windowView = view;
                return true;
            }
            windowView = default;
            return false;
        }
    }
}