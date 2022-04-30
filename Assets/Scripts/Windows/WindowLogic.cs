using UnityEngine;

namespace Windows
{
    public abstract class WindowLogic<View, Data> : IWindowLogic
        where View : Component, IWindowView
        where Data : IWindowData
    {
        private View _windowView;

        public abstract string Path { get; }
        protected abstract void Open(Data data);

        public virtual void Open()
        {
            SetVisible(true);
        }

        public virtual void Open(IWindowData data)
        {
            SetVisible(true);
            if (data is Data loadingData)
            {
                Open(loadingData);
            }
        }

        public virtual void Close()
        {
            ObjectPooler.PushBack(_windowView.gameObject);
            WindowsController.OnClose(this);
        }

        public virtual void SetVisible(bool isActive)
        {
            if (TryGetWindowView(out var windowView))
            {
                windowView.SetVisible(isActive);
            }
        }

        public void SetupView()
        {
            if (ObjectPooler.TryGetObject(Path, out var windowObj) is false)
            {
                return;
            }
            _windowView = windowObj.GetComponent<View>();
            _windowView.SetLogic(this);
            HUD.InterfaceController.ShowWindow(_windowView);
        }

        protected virtual void BackBehaviour()
        {
            Close();
        }

        protected bool TryGetWindowView(out View windowView)
        {
            if (_windowView != null)
            {
                windowView = _windowView;
                return true;
            }
            windowView = default;
            return false;
        }
    }
}