using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    public List<Enemy> enemies;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    //void FixedUpdate()
    //{
    //    objectPooler.SpawnFromPool("Enemy2", transform.position, Quaternion.identity);
    //}


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            objectPooler.SpawnFromPool("Enemy2", transform.position, Quaternion.identity);
            objectPooler.SpawnFromPool("Enemy1", transform.position, Quaternion.identity);
        }
        
        
    }
}
