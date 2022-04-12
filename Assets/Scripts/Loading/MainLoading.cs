using Cysharp.Threading.Tasks;
using Loading.Steps;
using System.Threading;

namespace Loading
{
    public class MainLoading
    {
        private CancellationTokenSource _cancelLoading;

        public MainLoading()
        {
            _cancelLoading = new CancellationTokenSource();

            var mainLoading = new LoadingInTurn(
                 new ConfigStep(),
                 new MainLoadingCompleteStep()
                 );

            mainLoading.Load(_cancelLoading.Token).Forget();
        }

        public void StopLoading()
        {
            _cancelLoading.Cancel();
        }
    }
}