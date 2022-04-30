using UnityEngine;

namespace Windows
{
    public interface IWindowView
    {
#pragma warning disable IDE1006 // Стили именования
        public Transform transform { get; }
        public GameObject gameObject { get; }
#pragma warning restore IDE1006 // Стили именования
        public void SetVisible(bool isActive);
        public void SetLogic(IWindowLogic logic);
    }
}