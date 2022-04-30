using UnityEngine;

public static class PrefabLoader
{
    public static bool TryGetObject<T>(string path, out T createdObj) where T: Object
    {
        //Utils.DebugUtils.LogError($"GetObject {path}");
        var objRes = Resources.Load<T>(path);
        if (objRes == null)
        {
            createdObj = default;
            return false;
        }
        createdObj = Object.Instantiate<T>(objRes);
        return true;
    }
}
