using Cysharp.Threading.Tasks;
using System.Threading;
using Windows;
using Windows.Loading;

namespace Loading.Steps
{
    public class WindowsStep : ILoading
    {
        public UniTask Load(CancellationToken cancelLoading)
        {
            WindowsController.Open<WindowLoading>();
            return UniTask.CompletedTask;
        }
    }
}