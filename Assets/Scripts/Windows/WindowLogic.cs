using Pool;

namespace Windows
{
    public interface IWindowData { }

    public class WindowLogic : IPoolCreator
    {
        protected WindowView windowView;

        public virtual string Path { get; }

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
            SetVisible(false);
        }

        public virtual void SetVisible(bool isActive)
        {

        }

        public virtual void BackBehaviour()
        {

        }

        public void CreateObj()
        {
            windowView = PrefabLoader.GetObject<WindowView>(Path);
        }
    }
}