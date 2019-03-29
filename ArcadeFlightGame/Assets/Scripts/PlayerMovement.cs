﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    //Plane Speeds
    public float velocity;
    //Speed of Arrow Key movement
    public float directionalSpeed;
    //Speed of Turn Rotation(A & D Keys)
    public float turnSpeed;
    //Plane Roll Angle
    public float roll;
    //Plane Pitch Value
    public float pitch;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("PlayerMovement Script Added To: " + gameObject.name);
    }

    // Update is called once per frame
    void Update() {

        //Set Initial Forward Motion
        transform.Translate(0, 0, transform.forward * velocity * Time.deltaTime, Space.World);

        #region Arrow Movement
        //------------Setup Initial Arrow Flight Movement---------------

        //------Up Arrow Key------

        //When Up Arrow key is pushed down
        if(Input.GetKey(KeyCode.UpArrow)) {
            //Transform Position Z to Move Player Up
            transform.Translate(0, transform.up.y * directionalSpeed * Time.deltaTime, 0, Camera.main.transform);
        }

        /*//Rotation handling for Up Arrow
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.Rotate(-pitch, 0, 0);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow)) {
            transform.Rotate(pitch, 0, 0);
        }*/

        //------Down Arrow Key------

        //When Down Arrow key is pushed down
        if(Input.GetKey(KeyCode.DownArrow)) {
            //Transform Position Z to Move Player Down
            transform.Translate(0, transform.up.y * -directionalSpeed * Time.deltaTime, 0, Camera.main.transform);
        }

        /*//Rotation handling for Down Arrow
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.Rotate(pitch, 0, 0);
        }

        if(Input.GetKeyUp(KeyCode.DownArrow)) {
            transform.Rotate(-pitch, 0, 0);
        }*/

        //------Right Arrow Key------

        //When Right Arrow key is pushed down
        if(Input.GetKey(KeyCode.RightArrow)) {
            //Transform Position Z to Move Player Right
            transform.Translate((transform.right.x) * directionalSpeed * Time.deltaTime, 0, 0, Camera.main.transform);
        }
        
        //Rotation handling for Right Arrow
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, -roll);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, roll);
        }

        //------Left Arrow Key------

        //When Left Arrow Key is pushed down
        if(Input.GetKey(KeyCode.LeftArrow)) {
            //Transform Position Z to Move Player Left
            transform.Translate((transform.right.x) * -directionalSpeed * Time.deltaTime, 0, 0, Camera.main.transform);
        }

        
        //Rotation handling for Left Arrow
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, roll);
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, -roll);
        }

        #endregion



        //------TAKE OUT LATER
        //Turn Ship Left
        if(Input.GetKey(KeyCode.A)) {
            transform.Rotate(0, -turnSpeed, 0, Space.World);
        }

        //------TAKE OUT LATER
        //Turn Ship Right
        if(Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, turnSpeed, 0, Space.World);
        }


        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            
    }
}
