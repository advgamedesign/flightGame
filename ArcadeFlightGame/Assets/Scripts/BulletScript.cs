using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 300f;
    [SerializeField] private float offset = 50f;
    [SerializeField] private GameObject shooter;
    private Rigidbody rb;
    // Update is called once per frame

    private void Start()
    {
          
    }

    void FixedUpdate()
    {

        //rb.AddForce(transform.forward * speed);
        transform.Translate(shooter.transform.position.x, shooter.transform.position.y, speed * Time.deltaTime, Space.World);
    }


}
