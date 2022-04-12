using Loading;
using UnityEngine;
using Utils;

public class Game : MonoBehaviour
{
    private MainLoading _mainLoading;

    private void Start()
    {
        _mainLoading = new MainLoading();
    }
}