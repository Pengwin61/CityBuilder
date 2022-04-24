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
           var enemy = ObjectPooler.GetObject("Enemies/Enemy1").transform;

            enemy.position = transform.position;
            enemy.rotation = Quaternion.identity;
        }
    }
}
