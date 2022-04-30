using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && 
            ObjectPooler.TryGetObject("Enemies/Enemy1", out var enemyObj))
        {
            var enemy = enemyObj.transform;
            enemy.position = transform.position;
            enemy.rotation = Quaternion.identity;
        }
    }
}
