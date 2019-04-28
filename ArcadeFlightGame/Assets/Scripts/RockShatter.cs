using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShatter : MonoBehaviour
{
    public GameObject rockShattered;
    public int health = 2;
    public Material mat;
    private Renderer rend;

    private void OnTriggerEnter(Collider other)
    {

        if(other.name == "PlayerShip")
        {
            Instantiate(rockShattered, transform.position, transform.rotation);
            //rockShattered.GetComponent<Renderer>().material = mat;
            Destroy(gameObject);
        }


    
        if(other.tag == "playerBullet") {
            health--;
            
            Destroy(other);
            
            if (health > 0)
            {
                GetComponent<Renderer>().material = mat; 
            }

            else
            {
                Instantiate(rockShattered, transform.position, transform.rotation);
                //rockShattered.GetComponent<Renderer>().material = mat;
                Destroy(gameObject);
            }
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
             health--;

            if (health > 0)
            {
                GetComponent<Renderer>().material = mat;
            }

            else
            {
                Instantiate(rockShattered, transform.position, transform.rotation);
                //rockShattered.GetComponent<Renderer>().material = mat;
                Destroy(gameObject);
            }
        }
    }
    
    
}
