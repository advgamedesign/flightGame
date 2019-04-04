using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotationSpeed;
    public float driftSpeed;

    private Vector3 rotationAxis;
    private Vector3 driftDirection;

    // Start is called before the first frame update
    void Start()
    {
       
        rotationAxis = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
        driftDirection = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(driftDirection * driftSpeed * Time.deltaTime);
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
