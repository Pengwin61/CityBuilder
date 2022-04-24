using UnityEngine;
using Windows;

namespace HUD
{
    public class InterfaceView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Transform _holder;

        public void ShowWindow(WindowView windowView)
        {
            windowView.transform.SetParent(_holder);
        }
    }
}