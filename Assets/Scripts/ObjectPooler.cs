using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string path;
        public int size;
    }

    private static ObjectPooler _instance;

    [SerializeField] private List<Pool> pools;
    [SerializeField] private Transform _container;

    private readonly Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public static void Init()
    {
        _instance.CreateStartPoolObjects();
    }

    public static bool TryGetObject(string path, out GameObject obj)
    {
        return _instance.TrySpawnFromPool(path, out obj);
    }

    public static void PushBack(GameObject obj)
    {
        _instance.Push(obj);
    }

    private bool TryCreateObject(string path)
    {
        if (PrefabLoader.TryGetObject<GameObject>(path, out var obj) is false)
        {
            return false;
        }
        obj.name = path;
        Push(obj);
        return true;
    }

    private void Push(GameObject prefab)
    {
        var path = prefab.name;
        prefab.transform.SetParent(_container);
        if (poolDictionary.ContainsKey(path) is false)
        {
            poolDictionary.Add(path, new Queue<GameObject>());
        }
        poolDictionary[path].Enqueue(prefab);
    }

    private void CreateStartPoolObjects()
    {
        foreach (Pool pool in pools)
        {
            for (int i = 0; i < pool.size; i++)
            {
                var isSuccess = TryCreateObject(pool.path);
                if (isSuccess is false)
                {
                    break;
                }
            }
        }
    }

    private bool TrySpawnFromPool(string path, out GameObject objectToSpawn)
    {
        if (!poolDictionary.ContainsKey(path) || poolDictionary[path].Count == 0)
        {
            var isSuccess = TryCreateObject(path);
            if (isSuccess is false)
            {
                objectToSpawn = default;
                return false;
            }
        }
        objectToSpawn = poolDictionary[path].Dequeue();
        objectToSpawn.transform.SetParent(null);
        return true;
    }

    private void Awake()
    {
        _instance = this;
    }
}
