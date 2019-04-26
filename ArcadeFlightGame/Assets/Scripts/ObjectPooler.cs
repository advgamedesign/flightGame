using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ObjectPoolItem Class
[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
}


//Object Pooler Class
public class ObjectPooler : MonoBehaviour
{
    //Setup Variables
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> pooledObjects;

    public static ObjectPooler SharedInstance;

    //Set the ObjectPooler to this class
    void Awake()
    {
        SharedInstance = this;
    }

    //Start method called once at beginning of Game
    void Start()
    {
        //Create List of pooledObjects
        pooledObjects = new List<GameObject>();

        //for each objectPoolItem in the list
        foreach(ObjectPoolItem item in itemsToPool) {
            //For amount
            for(int i = 0; i < item.amountToPool; i++) {
                //Instantiate an object
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                //Deactivate the object
                obj.SetActive(false);
                //Add object to pool
                pooledObjects.Add(obj);
            }
        }

    }

    //Get method for pooledObjects
    public GameObject GetPooledObject(string tag)
    {
        //for total amount of poolObjects created
        for(int i = 0; i < pooledObjects.Count; i++) {
            //If current object is not active
            if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag) {
                //return that object
                return pooledObjects[i];
            }
        }

        foreach(ObjectPoolItem item in itemsToPool) {
            if(item.objectToPool.tag == tag) {
                //if we should expand the pool
                if(item.shouldExpand) {
                    //add more objects to the pool
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }  
            }
        }

        //otherwise return null
        return null;

    }
}
