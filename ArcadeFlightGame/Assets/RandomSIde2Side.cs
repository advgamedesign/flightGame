using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSIde2Side : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    public float bulletSpeed;
    private int height;

    private int current;
    private bool firing = false;
    private bool startFiring = false;
    public GameObject bullet;
    public GameObject player;
    public Transform bulletSpawner;

    public float spawnTime;
    public float spawnDelay;
    //public int delayMultiplier;




    private void Start()
    {
        current = Random.Range(0, 3);
        height = Random.Range(-10, 10);
        
        foreach(Transform point in points)
        {
            point.position = point.position + Vector3.up * height;
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == points[current].name)
        {
            speed = 30;
            startFiring = true;

        }

    }

    private void Update()
    {
        if(player.transform.position.z > transform.position.z - 50)
        {
            firing = false;
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
            
       
            Instantiate(bullet,bulletSpawner.position, bulletSpawner.rotation);
            
            Vector3 p = Vector3.MoveTowards(transform.position, player.transform.position, bulletSpeed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(-p);

    }

}
