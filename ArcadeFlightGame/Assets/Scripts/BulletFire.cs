using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [SerializeField] private float fireTime = 1f;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private GameObject playerShip;

    [SerializeField] private int amountOfBullets = 40;
    List<GameObject> bullets;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate all bullets
        bullets = new List<GameObject>();
        for(int i = 0; i < amountOfBullets; i++) {
            GameObject obj = (GameObject)Instantiate(bulletObject, playerShip.transform.forward, Quaternion.identity);
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }

    // Update is called once per frame
    public void Fire()
    {
        for(int i = 0; i < bullets.Count; i++) {
            if(!bullets[i].activeInHierarchy) {
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }
    }
}