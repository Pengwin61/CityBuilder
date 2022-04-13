using UnityEngine;

public static class PrefabLoader
{
    public static T GetObject<T>(string path) where T: MonoBehaviour
    {
        var objRes = Resources.Load<T>(path);
        var createdObj = Object.Instantiate<T>(objRes);
        return createdObj;
    }

    public static GameObject GetObject(string path)
    {
        var objRes = Resources.Load<GameObject>(path);
        var createdObj = GameObject.Instantiate<GameObject>(objRes);
        return createdObj;
    }
}
