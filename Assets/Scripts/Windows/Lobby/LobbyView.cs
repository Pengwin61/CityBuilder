using UnityEngine;

namespace Windows.Lobby
{
    public class LobbyView : WindowView<WindowLobby>
    {
        public void OnStartClick()
        {
            logic.OnStartClick();
        }
    }
}