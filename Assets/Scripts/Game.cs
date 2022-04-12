using Loading;
using UnityEngine;
using Utils;

public class Game : MonoBehaviour
{
    private static readonly SingletonesHandler Instances = new SingletonesHandler();

    private MainLoading _mainLoading;

    private void Start()
    {
        _mainLoading = new MainLoading();
    }
}