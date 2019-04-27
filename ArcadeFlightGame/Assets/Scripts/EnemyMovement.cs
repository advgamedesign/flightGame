using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] points;
    public float speed;

    private int current;


    private void OnTriggerEnter(Collider other)
    {

        if (other.name == points[0].name)
        {
            speed = 30;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (transform.position != points[current].position)
        {

            Vector3 p = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(p);

        }

        else
        {
            current = (current + 1) % points.Length;
        }
    }
}
