using UnityEngine;

namespace Windows
{
    public class WindowView : MonoBehaviour
    {
        private WindowLogic _windowLogic;

        public void SetLogic(WindowLogic windowLogic)
        {
            _windowLogic = windowLogic;
        }

        public void SetVisible(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}