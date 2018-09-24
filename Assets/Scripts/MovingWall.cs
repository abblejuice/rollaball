using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{

    public float speed;

	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed, 0);
        if (transform.position.y >= 5f || transform.position.y < 1.085)
        {
            speed = speed * -1;

        }



    }
}
