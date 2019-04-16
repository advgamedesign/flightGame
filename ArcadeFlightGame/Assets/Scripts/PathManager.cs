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
        currentPath = (GameObject)Instantiate(pathPrefabs[2], currentPath.transform.GetChild(1).position, Quaternion.identity);

    }
}
