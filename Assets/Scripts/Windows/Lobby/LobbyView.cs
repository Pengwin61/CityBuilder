using UnityEngine;

namespace Windows.Lobby
{
    public class LobbyView : WindowView<WindowLobby>
    {
        public void OnStartClick()
        {
            Debug.LogError($"OnStartClick");
            logic.OnStartClick();
        }
    }
}