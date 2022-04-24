namespace Windows.Loading
{
    public class WindowLoading : WindowLogic
    {
        private const string PATH = "Windows/WindowLoading";
        public override string Path => PATH;

        public override void Open(IWindowData data)
        {
            base.Open(data);
            if (data is LoadingData loadingData)
            {
                OpenInteral(loadingData);
            }
        }

        private void OpenInteral(LoadingData loadingData)
        {
            if (TryGetWindowView<LoadingView>(out var loadingView))
            {
                loadingView.SetLoadingSteps(loadingData.steps);
            }
        }
    }
}