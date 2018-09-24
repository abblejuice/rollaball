using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    void Start()
    {

    }

   
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);
        if (transform.position.x <= -4f || transform.position.x >= 8f)
        {
            speed = speed * -1;

        }



    }
}

