using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] points;
    public float speed;

    private int current;
    private bool firing = false;
    private bool startFiring = false;
    public GameObject bullet;
    public GameObject player;
    public Transform bulletSpawner;

    public float spawnTime;
    public float spawnDelay;
    //public int delayMultiplier;


    private void OnTriggerEnter(Collider other)
    {

        if (other.name == points[0].name)
        {
            speed = 30;
            startFiring = true;
        }

    }

    private void Update()
    {
        if (player.transform.position.z > transform.position.z - 50)
        {
            firing = false;
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

        if (startFiring)
        {
            if (!firing)
            {
                firing = true;
                InvokeRepeating("SpawnNewBullet", spawnTime, spawnDelay);
            }

        }
    }

    public void SpawnNewBullet()
    {


        Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);

        

    }
}
