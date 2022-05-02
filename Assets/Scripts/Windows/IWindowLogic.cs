namespace Windows
{
    public interface IWindowLogic
    {
        void Open();
        void Close();
        void SetVisible(bool isActive);
    }

    public interface IWindowLogicWithData : IWindowLogic
    {
        void Open(IWindowData data);
    }
}