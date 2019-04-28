using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 300f;
    [SerializeField] private float offset = 30f;
    [SerializeField] private GameObject shooter;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(shooter.transform.position.x, shooter.transform.position.y, speed * Time.deltaTime, Space.World);
    }


}
