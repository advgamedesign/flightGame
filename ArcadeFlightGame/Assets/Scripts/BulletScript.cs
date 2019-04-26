using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 300f;
    public GameObject shooter;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(shooter.transform.position.x, shooter.transform.position.y, speed * Time.deltaTime);
    }
}
