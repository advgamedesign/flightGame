using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start() {
        Debug.Log("PlaneMovement Script Added To: " + gameObject.name);
    }

    // Update is called once per frame
    void Update() {
        Vector3 moveCamTo = transform.position - transform.forward * 50.0f + Vector3.up * 5.0f;
        Camera.main.transform.position = moveCamTo;
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);



        transform.position += transform.forward * Time.deltaTime * speed;

        speed -= transform.forward.y * Time.deltaTime * 50.0f;

        if(speed < 10.0f) {
            speed = 10.0f;
        }


        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -2 * Input.GetAxis("Horizontal"));

        float terrainHeightAtPosition = Terrain.activeTerrain.SampleHeight(transform.position);

        if(terrainHeightAtPosition > transform.position.y) {
            transform.position = new Vector3(transform.position.x, terrainHeightAtPosition, transform.position.z);
        }
    }
}
