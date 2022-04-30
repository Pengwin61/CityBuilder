namespace Windows.Loading
{
    public class WindowLoading : WindowLogic<LoadingView, LoadingData>
    {
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