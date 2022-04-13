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

    private Dictionary<string, Queue<GameObject>> poolDictionary;

    public static void Init()
    {
        _instance.CreateStartPoolObjects();
    }

    public static GameObject GetObject(string path)
    {
        return _instance.SpawnFromPool(path);
    }

    public static void PushBack(GameObject obj)
    {
        _instance.Push(obj);
    }

    private void CreateObject(string path)
    {
        var obj = PrefabLoader.GetObject(path);
        obj.name = path;
        Push(obj);
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
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            for (int i = 0; i < pool.size; i++)
            {
                CreateObject(pool.path);
            }
        }
    }

    private GameObject SpawnFromPool(string path)
    {
        if (!poolDictionary.ContainsKey(path) || poolDictionary[path].Count == 0)
        {
            CreateObject(path);
        }
        var objectToSpawn = poolDictionary[path].Dequeue();
        objectToSpawn.transform.SetParent(null);
        return objectToSpawn;
    }

    private void Awake()
    {
        _instance = this;
    }
}
