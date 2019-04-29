using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float destroyTime = 2f;
    void OnEnable()
    {
        Invoke("Destroy", destroyTime);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
        //Debug.Log("Destroyed");
    }

    void OnDisable()
    {
        CancelInvoke();
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Terrain")
        {
            Destroy();
        }
         
       

    }*/
}
