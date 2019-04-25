using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] points;
    public float speed;

    private int current;


    // Update is called once per frame
    void Update()
    {
        if (transform.position != points[current].position)
        {

            Vector3 pos = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

        }

        else
        {
            current = (current + 1) % points.Length;
        }
    }
}
