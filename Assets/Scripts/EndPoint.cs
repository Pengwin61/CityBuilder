using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        GameObject enemyGO = collision.gameObject;
        if (enemyGO.tag == "Enemy")
        {
            ObjectPooler.PushBack(enemyGO);
            print("Я выключил " + enemyGO.name);
        }
        else
        {
            print("Какая-то шляпа " + enemyGO.name + " попала в коллайдер");
        }
    }
}
