using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private void Start()
    {
        ObjectPooler.Init();
    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //ObjectPooler.GetObject("Enemy2", transform.position, Quaternion.identity);
            //ObjectPooler.GetObject("Enemy1", transform.position, Quaternion.identity);
            ObjectPooler.GetObject(PoolType.Enemy1, transform.position, Quaternion.identity);
        }
        
        
    }
}
