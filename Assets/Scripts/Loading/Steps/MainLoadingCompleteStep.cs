using Cysharp.Threading.Tasks;
using System.Threading;
using Windows;
using Windows.Loading;
using Windows.Lobby;

namespace Loading.Steps
{
    public class MainLoadingCompleteStep : ILoading
    {
        public UniTask Load(CancellationToken cancelLoading)
        {
            WindowLoading.Hide();
            WindowsController.Open<WindowLobby>();
            return UniTask.CompletedTask;
        }
    }
}