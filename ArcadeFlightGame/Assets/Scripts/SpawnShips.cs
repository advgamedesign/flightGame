using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShips : MonoBehaviour
{
    public GameObject ship;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public int ships;
    public int spawned;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewShip", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    public void SpawnNewShip()
    {
        if (spawned <= ships)
        {
            Instantiate(ship, transform.position, transform.rotation);
            spawned++;
        }
        else
        {
            CancelInvoke("SpawnNewShip");
        }
    }
}
