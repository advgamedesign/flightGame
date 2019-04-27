using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationMovement : MonoBehaviour
{

    public Transform[] rail;
    public float speed;

    private int current;
    public int time = 2;
    public float force = 200;



    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != rail[current].position)
        {

            Vector3 pos = Vector3.MoveTowards(transform.position, rail[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

        }

        else
        {
            if (current != rail.Length - 1)
            {
                current = (current + 1) ;
            }
            else
            {
                //Destroy(gameObject, time);
            }

        }
    }
}

