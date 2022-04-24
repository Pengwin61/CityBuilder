using Cysharp.Threading.Tasks;
using Loading.Steps;
using System.Threading;
using UnityEngine;
using Windows;
using Windows.Loading;

namespace Loading
{
    public class MainLoading
    {
        private readonly CancellationTokenSource _cancelLoading;

        public MainLoading()
        {
            _cancelLoading = new CancellationTokenSource();

            var mainLoading = new LoadingInTurn(
                 new ConfigStep(),
                 new MainLoadingCompleteStep()
                 );

            WindowsController.Open<WindowLoading>(new LoadingData { steps = mainLoading });
            mainLoading.Load(_cancelLoading.Token).Forget();
        }

        public void StopLoading()
        {
            _cancelLoading.Cancel();
        }

        public class Test : ILoading
        {
            private int delay;

            public Test(int delay)
            {
                this.delay = delay;
            }

            public async UniTask Load(CancellationToken cancelLoading)
            {
                await UniTask.Delay(delay);
                Debug.LogError($"complete {delay}");
            }
        }
    }
}