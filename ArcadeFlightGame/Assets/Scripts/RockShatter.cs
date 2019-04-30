using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShatter : MonoBehaviour
{
    public GameObject rockShattered;
    public int health = 2;
    public Material mat;
    private Renderer rend;




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {


            Instantiate(rockShattered, transform.position, transform.rotation);
            Destroy(gameObject);

            PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerHealth") - 1);
            Debug.Log(PlayerPrefs.GetInt("PlayerHealth"));

        }

        if(collision.collider.tag == "playerBullet")
        {
            health--;

            if (health > 0)
            {
                GetComponent<Renderer>().material = mat;
                PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 100);
                collision.collider.gameObject.SetActive(false);
            }

            else
            {


                Instantiate(rockShattered, transform.position, transform.rotation);
                //rockShattered.GetComponent<Renderer>().material = mat;
                Destroy(gameObject);
                PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 500);
                collision.collider.gameObject.SetActive(false);
            }
        }


    }

   /* private void OnTriggerExit(Collider other)
    {
        if (other.tag == "playerBullet")
        {
            health--;

            Destroy(other);

            if (health > 0)
            {
                GetComponent<Renderer>().material = mat;
                PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 100);
            }

            else
            {


                Instantiate(rockShattered, transform.position, transform.rotation);
                //rockShattered.GetComponent<Renderer>().material = mat;
                Destroy(gameObject);
                PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 500);
                other.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            Instantiate(rockShattered, transform.position, transform.rotation);
             Destroy(gameObject);
            PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerHealth") - 1);
            Debug.Log(PlayerPrefs.GetInt("PlayerHealth"));
        }



        if (other.tag == "playerBullet")
        {
            health--;

            Destroy(other);

            if (health > 0)
            {
                GetComponent<Renderer>().material = mat;
                PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 100);
            }

            else
            {


                Instantiate(rockShattered, transform.position, transform.rotation);
                //rockShattered.GetComponent<Renderer>().material = mat;
                Destroy(gameObject);
                PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 500);
                other.gameObject.SetActive(false);
            }
        }

    }*/

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
