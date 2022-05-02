using UnityEngine;

namespace Windows
{
    public abstract class WindowLogicWithData<View, Data> : WindowLogic<View>, IWindowLogicWithData
        where View : Component, IWindowView
        where Data : struct, IWindowData
    {
        public void Open(IWindowData data)
        {
            Open();
            if (data is Data loadingData)
            {
                Open(loadingData);
            }
        }

        protected virtual void Open(Data data) { }
    }
}