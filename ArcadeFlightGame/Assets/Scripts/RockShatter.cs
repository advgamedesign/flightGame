using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShatter : MonoBehaviour
{
    public GameObject rockShattered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerShip") {
            Instantiate(rockShattered, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
