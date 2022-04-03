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
            enemyGO.SetActive(false);
            print("� �������� " + enemyGO.name);
        }
        else
        {
            print("�����-�� ����� " + enemyGO.name + " ������ � ���������");
        }
    }
}
