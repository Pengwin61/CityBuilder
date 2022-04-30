using UnityEngine;

namespace Windows
{
    public class WindowView<WindowLogic> : MonoBehaviour, IWindowView 
        where WindowLogic : IWindowLogic
    {
        public WindowLogic logic;


        public void SetLogic(IWindowLogic incomeLogic)
        {
            if (incomeLogic is WindowLogic neededLogic)
            {
                logic = neededLogic;
            }
        }

        public void SetVisible(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}