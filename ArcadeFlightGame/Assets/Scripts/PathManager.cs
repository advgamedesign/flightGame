using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{

    public GameObject rightTurnPrefab;

    public GameObject leftTurnPrefab;

    public GameObject strightPrefab;

    public GameObject splitPrefab;

    public GameObject[] pathPrefabs;

    public GameObject currentPath;

    // Start is called before the first frame update
    void Start()
    {
       // for (int i = 0; i < 10; i++)
        //{
            SpawnPath();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPath()
    {
        currentPath = (GameObject)Instantiate(leftTurnPrefab, currentPath.transform.GetChild(0).position, Quaternion.identity);
    }
}
