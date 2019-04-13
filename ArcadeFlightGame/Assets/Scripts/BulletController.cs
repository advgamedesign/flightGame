using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 300f;
    public int amountOfBullets;

    private List<GameObject> bulletList;

    // Start is called before the first frame update
    void Start()
    {
        bulletList = new List<GameObject>();

        for(int i = 0; i < amountOfBullets; i++) {
            GameObject objBullet = (GameObject)Instantiate(bullet);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
