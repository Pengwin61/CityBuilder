using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;


    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.z -= speed * Time.deltaTime;
        pos = tempPos;
    }


    void Update()
    {
        Move();
    }

}
