using UnityEngine;

public static class PrefabLoader
{
    public static T GetObject<T>(string path) where T: MonoBehaviour
    {
        var objRes = Resources.Load<T>(path);
        var createdObj = Object.Instantiate(objRes);
        return createdObj;
    }
}
