using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreEnemyBullet : MonoBehaviour
{

    public GameObject bullet;

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.gameObject.tag == "enemyBullet")
        Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
    }

}
