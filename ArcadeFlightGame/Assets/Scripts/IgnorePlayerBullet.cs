using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerBullet : MonoBehaviour
{

    public GameObject bullet;

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.gameObject.tag == "playerBullet")
        Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
    }

}
