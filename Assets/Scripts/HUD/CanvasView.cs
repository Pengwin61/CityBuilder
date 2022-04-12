using UnityEngine;
using Windows;

namespace HUD
{
    public class CanvasView : MonoBehaviour
    {
        [SerializeField] private WindowsContainer _windowContainer;

        public WindowsContainer WindowsContainer => _windowContainer;
    }
}