using Cysharp.Threading.Tasks;
using Loading;
using System.Threading;
using Windows.Loading;

namespace Windows.Lobby
{
    public class WindowLobby : WindowLogic<LobbyView, LobbyData>
    {
        private const string PATH = "Windows/WindowLobby";
        public override string Path => PATH;
        protected override void Open(LobbyData data) { }

        public void OnStartClick()
        {
            var loadBattle = new LoadingInTurn(
                new MainLoading.LoadingTest(1500),
                new MainLoading.LoadingTest(1000),
                new MainLoading.LoadingTest(500),
                new MainLoading.LoadingTest(100)
                );

            WindowsController.Open<WindowLoading>(new LoadingData { steps = loadBattle });

            var cancelLoading = new CancellationTokenSource();
            loadBattle.Load(cancelLoading.Token).Forget();
        }
    }
}