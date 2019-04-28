using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotationSpeed;
    public float driftSpeed;

    private Vector3 rotationAxis;
    private Vector3 driftDirection;

    private int health;

    //Set Minimum/Maximum Height
    [SerializeField] private float MaxHeight = 30;
    [SerializeField] private float MinHeight = 0;


    // Start is called before the first frame update
    void Start()
    {
       
        rotationAxis = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
        driftDirection = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
        health = 3;


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(driftDirection * driftSpeed * Time.deltaTime);
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

        if (transform.position.y >= MaxHeight)
        {
            transform.position = new Vector3(transform.position.x, MaxHeight, transform.position.z);
            driftDirection = driftDirection * -1;
        }
            
        if (transform.position.y <= MinHeight)
        {
            transform.position = new Vector3(transform.position.x, MinHeight, transform.position.z);
            driftDirection = driftDirection * -1;
        }
            

    }
}
