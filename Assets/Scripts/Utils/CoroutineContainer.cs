using UnityEngine;
using System;
using System.Collections;

/// <summary> class to start coroutines NOT from monoBehaviours </summary>
public class CoroutineContainer : MonoBehaviour
{
    private static CoroutineContainer _instance;

    private static CoroutineContainer Instance
    {
        get
        {
            if (_instance == null)
            {
                Init();
            }
            return _instance;
        }
    }

    private static void Init()
    {
        GameObject go = new GameObject();
        _instance = go.AddComponent<CoroutineContainer>();
        go.name = nameof(CoroutineContainer);
        DontDestroyOnLoad(go);
    }

    public static Coroutine Start(IEnumerator routine) =>
        Instance.StartCoroutine(routine);

    public static void Stop(Coroutine coroutine) =>
        Instance.StopCoroutine(coroutine);


    public static Coroutine DelayAction(float seconds, Action action) =>
        Instance.StartCoroutine(DelayActionRoutine(Yielders.WaitForSeconds(seconds), action));
    public static Coroutine DelayAction(float seconds, Action action, MonoBehaviour onMonoBeh) =>
        DelayAction(Yielders.WaitForSeconds(seconds), action, onMonoBeh);


    public static Coroutine DelayRealtimeAction(float seconds, Action action) =>
        Instance.StartCoroutine(DelayActionRoutine(Yielders.WaitForSecondsRealtime(seconds), action));
    public static Coroutine DelayRealtimeAction(float seconds, Action action, MonoBehaviour onMonoBeh) =>
        DelayAction(Yielders.WaitForSecondsRealtime(seconds), action, onMonoBeh);


    public static Coroutine Swing(Func<float, IEnumerator> action, float coeffSpeed, float duration, MonoBehaviour onMonoBeh)
    {
        return onMonoBeh.StartCoroutine(SwingInternal(action, coeffSpeed, duration));
    }


    private static Coroutine DelayAction(IEnumerator yielder, Action action, MonoBehaviour onMonoBeh)
    {
        if (onMonoBeh == null || !onMonoBeh.isActiveAndEnabled)
        {
            DebugCustom.LogWarning("Trying to start coroutine on destroyed or inactive MonoBehaviour. Return null without consequences");
            return null;
        }
        return onMonoBeh.StartCoroutine(DelayActionRoutine(yielder, action));
    }
    private static Coroutine DelayAction(YieldInstruction yielder, Action action, MonoBehaviour onMonoBeh)
    {
        if (onMonoBeh == null || !onMonoBeh.isActiveAndEnabled)
        {
            DebugCustom.LogWarning("Trying to start coroutine on destroyed or inactive MonoBehaviour. Return null without consequences");
            return null;
        }
        return onMonoBeh.StartCoroutine(DelayActionRoutine(yielder, action));
    }


    private static IEnumerator DelayActionRoutine(IEnumerator yielder, Action action)
    {
        yield return yielder;
        action?.Invoke();
    }    
    private static IEnumerator DelayActionRoutine(YieldInstruction yielder, Action action)
    {
        yield return yielder;
        action?.Invoke();
    }


    private static IEnumerator SwingInternal(Func<float, IEnumerator> action, float coeffSpeed, float duration)
    {
        var from = 0f;
        var to = 1f;

        action?.Invoke(from);
        for (var t = from; t < to; t += Time.deltaTime * coeffSpeed)
        {
            yield return action?.Invoke(t);
        }
        action?.Invoke(to);
        yield return Yielders.WaitForSeconds(duration);
        for (var t = to; t > from; t -= Time.deltaTime * coeffSpeed)
        {
            yield return action?.Invoke(t);
        }
        action?.Invoke(from);
    }
}