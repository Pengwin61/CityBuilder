using UnityEngine;

namespace Windows
{
    public abstract class WindowLogic<View> : IWindowLogic
        where View : Component, IWindowView
    {
        private View _windowView;

        public abstract string Path { get; }

        public virtual void Open()
        {
            SetVisible(true);
            SetupView();
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

        protected void SetupView()
        {
            if (ObjectPooler.TryGetObject(Path, out var windowObj) is false)
            {
                return;
            }
            _windowView = windowObj.GetComponent<View>();
            _windowView.SetLogic(this);
            HUD.InterfaceController.ShowWindow(_windowView);
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

        protected virtual void BackBehaviour()
        {
            Close();
        }
    }
}