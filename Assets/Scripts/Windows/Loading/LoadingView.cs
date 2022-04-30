using Loading;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.Loading
{
    public class LoadingView : WindowView<WindowLoading>
    {
        [SerializeField] private Slider _slider;
        private LoadingSteps _steps;

        public void SetActiveSlider(bool isActive)
        {
            _slider.gameObject.SetActive(isActive);
        }

        public void SetLoadingSteps(LoadingSteps steps)
        {
            _steps = steps;
            _slider.maxValue = _steps.Count;
            _slider.value = 0;
            _steps.onComplete += OnStepComplete;
        }

        private void OnStepComplete(int stepsLeft)
        {
            _slider.value = _slider.maxValue - stepsLeft;
        }
    }
}