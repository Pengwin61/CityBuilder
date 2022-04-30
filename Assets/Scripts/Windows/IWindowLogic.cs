namespace Windows
{
    public interface IWindowLogic
    {
        void Open();
        void Open(IWindowData data);
        void Close();
        void SetVisible(bool isActive);
        void SetupView();
    }
}