using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    public int time = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }

    
}
