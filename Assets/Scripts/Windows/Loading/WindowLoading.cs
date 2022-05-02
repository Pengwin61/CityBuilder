using Loading;

namespace Windows.Loading
{
    public class WindowLoading : WindowLogicWithData<LoadingView, LoadingData>
    {
        public static void Show()
        {
            WindowsController.Open<WindowLoading>();
        }
        public static void Show(LoadingSteps loadingSteps)
        {
            WindowsController.Open<WindowLoading>(new LoadingData { steps = loadingSteps });
        }
        public static void Hide()
        {
            WindowsController.Close<WindowLoading>();
        }

        private const string PATH = "Windows/WindowLoading";
        public override string Path => PATH;

        public override void Open()
        {
            base.Open();
            if (TryGetWindowView(out var loadingView))
            {
                loadingView.SetActiveSlider(false);
            }
        }

        protected override void Open(LoadingData loadingData)
        {
            if (TryGetWindowView(out var loadingView))
            {
                loadingView.SetLoadingSteps(loadingData.steps);
                loadingView.SetActiveSlider(true);
            }
        }
    }
}