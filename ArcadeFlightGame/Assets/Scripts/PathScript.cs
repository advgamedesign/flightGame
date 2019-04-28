using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    //[SerializeField] private GameObject playerShip;
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider create)
    {
       
        if (create.CompareTag("Player"))
        {
            PathManager.Instance.SpawnPath();

        }
    }

    private void OnTriggerExit(Collider destory)
    {
        if (destory.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
