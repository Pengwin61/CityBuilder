namespace Windows.Lobby
{
    public class WindowLobby : WindowLogic<LobbyView>
    {
        private const string PATH = "Windows/WindowLobby";
        public override string Path => PATH;

        public void OnStartClick()
        {
            Close();
        }
    }
}