using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Initial Forward Velocity of Plane
    private float velocity = 10.0f;
    //Speed of Arrow Key movement
    private float directionalSpeed = 20.0f;
    //Plane Roll Angle
    private float roll = 5.0f;
    //Plane Pitch Value
    private float pitch = 10.0f;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("PlaneMovement Script Added To: " + gameObject.name);
    }

    // Update is called once per frame
    void Update() {

        //Set Initial Forward Motion
        transform.Translate(0, 0, velocity * Time.deltaTime);

        #region Arrow Movement
        //------------Setup Initial Arrow Flight Movement---------------

        //When Up Arrow key is pushed down
        if(Input.GetKey(KeyCode.UpArrow)) {
            //Transform Position Z to Move Player Up
            transform.Translate(0, 1 * directionalSpeed * Time.deltaTime, 0);
        }

        //When Down Arrow key is pushed down
        if(Input.GetKey(KeyCode.DownArrow)) {
            //Transform Position Z to Move Player Down
            transform.Translate(0, 1 * -directionalSpeed * Time.deltaTime, 0);
        }

        //When Right Arrow key is pushed down
        if(Input.GetKey(KeyCode.RightArrow)) {
            //Transform Position Z to Move Player Right
            transform.Translate(1 * directionalSpeed * Time.deltaTime, 0, 0);
        }

        /*
        //Rotation handling for Right Arrow
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, -roll);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, roll);
        }
        */

        //When Left Arrow Key is pushed down
        if(Input.GetKey(KeyCode.LeftArrow)) {
            //Transform Position Z to Move Player Left
            transform.Translate(1 * -directionalSpeed * Time.deltaTime, 0, 0);
        }

        /*
        //Rotation handling for Left Arrow
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, roll);
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, -roll);
        }
        */

        #endregion
    }
}
