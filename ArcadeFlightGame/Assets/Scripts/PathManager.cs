using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{

    public GameObject[] pathPrefabs;

    public GameObject currentPath;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 10; i++)
        {
            SpawnPath();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SpawnPath()
    {
        //Generating a random number between 0 and 3
        int randomIndex = Random.Range(0, 4);

        currentPath = (GameObject)Instantiate(pathPrefabs[randomIndex], currentPath.transform.GetChild(0).position, Quaternion.identity);

    }
    
}
