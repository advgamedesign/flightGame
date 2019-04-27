using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSIde2Side : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    private int height;

    private int current;
    private ArrayList modPoints;


    private void Start()
    {
        current = Random.Range(0, 3);
        height = Random.Range(-5, 5);
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == points[current].name)
        {
            speed = 30;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (transform.position != points[current].position)
        {

            Vector3 p = Vector3.MoveTowards(transform.position, points[current].position  , speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(p);

        }

        else
        {
            current = (current + 1) % points.Length;
        }
    }
}
