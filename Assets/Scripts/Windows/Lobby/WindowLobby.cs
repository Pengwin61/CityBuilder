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
            Close();

        }
    }
}