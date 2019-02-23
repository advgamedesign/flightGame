using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlaneMovement Script Added To: " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
    }
}
