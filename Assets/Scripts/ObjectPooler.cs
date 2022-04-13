using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PoolType
{
    Enemy1=1,
    Enemy2=2,
    Enemy3=3
}



public class ObjectPooler : MonoBehaviour
{

   [System.Serializable]
    public class Pool
    {
        public PoolType type;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion


    [SerializeField] 
    private List<Pool> pools;
    private Dictionary<PoolType, Queue<GameObject>> poolDictionary;

    [SerializeField]
    private Transform _container;


    public static void Init()
    {
        Instance.Initialization();
    }

    public static GameObject GetObject(PoolType poolType, Vector3 position, Quaternion rotation)
    {
        return Instance.SpawnFromPool(poolType, position, rotation);
    }

    public static void PushBack(GameObject obj)
    {
        
    }

    private void CreateObject(GameObject prefab, PoolType poolType)
    {
        GameObject obj = Instantiate(prefab);
        Push(obj,poolType);

    }

    private void Push(GameObject prefab, PoolType poolType)
    {
        prefab.transform.SetParent(_container);


        //Нужно сохранить , получает в словаре нужную очередь
        // Получить или как параметр в метод
        // Или вместо геймобжекта передавать другую структуру где будет и префаб или PooleType
        poolDictionary[poolType].Enqueue(prefab);
        
    }



    private void Initialization()
    {
        poolDictionary = new Dictionary<PoolType, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            // Вызываем метод добавить пул CreateObject
            
            Queue<GameObject> objectPool = new Queue<GameObject>();

            poolDictionary.Add(pool.type, objectPool);

            for (int i = 0; i < pool.size; i++)
            {
                CreateObject(pool.prefab,pool.type);
            }
            
        }
    }




    private GameObject SpawnFromPool(PoolType poolType, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolType))
        {
            Debug.LogWarning("Pool with tag " + tag + "doesn't excist.");
            return null;
        }

        // Переделать метод Криейт

        GameObject objectToSpawn = poolDictionary[poolType].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;


        return objectToSpawn;
    }





}
