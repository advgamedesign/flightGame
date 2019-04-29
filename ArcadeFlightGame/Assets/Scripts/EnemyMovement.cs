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
    public GameObject deathEffect;

    //-----------BULLET INFO VARIABLES----------
    [SerializeField] private float fireTime = 1f;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private GameObject enemyShip;

    [SerializeField] private int amountOfBullets = 40;
    List<GameObject> bullets;
    private bool isCoroutineExecuting = false;
    //private bool shouldExpand = true;
    public int timer;
    public int shipSpeed;



    private void Start()
    {
      

        bullets = new List<GameObject>();
        for (int i = 0; i < amountOfBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(bulletObject);
            obj.SetActive(false);
            bullets.Add(obj);
        }

        Destroy(gameObject, timer);

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.name == points[current].name)
        {
            speed = shipSpeed;
            startFiring = true;

        }

        if (other.tag == "playerBullet")
        {
            Die();
            PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 1000);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "playerBullet")
        {
            Die();
            PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 1000);
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


            firing = true;
            StartCoroutine("Fire", fireTime);


        }


    }

    IEnumerator Fire(float time)
    {

        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = transform.position + Vector3.forward * -50f + Vector3.right;
                bullets[i].transform.rotation = bulletObject.transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }

        yield return new WaitForSeconds(time);

        isCoroutineExecuting = false;
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);

        //Destroy the turret
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Die();
            PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerHealth") - 1);
        }
    }



}