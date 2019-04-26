using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Target we wish to follow
    public Transform target;
    //Camera Distance from Target
    public float distance = 10.0f;
    //Camera Height from Target
    public float height = 5.0f;
    //Damping Variables 
    public float heightDamping = 2.0f;
    public float yAxisRotationDamping = 3.0f;

    void LateUpdate()
    {
        //If target isn't set, return
        if(!target) {
            Debug.LogError("Target not set in Camera Script");
            return;
        }

        //Height Position Variables
        float wantedHeight = target.position.y + height;
        float currentHeight = transform.position.y;

        //Y-Axis Rotation Variables
        float wantedRotationAngleY = target.eulerAngles.y;
        float currentRotationAngleY = transform.eulerAngles.y;
        
        //Y-Axis Rotation Damping
        currentRotationAngleY = Mathf.LerpAngle(currentRotationAngleY, wantedRotationAngleY, yAxisRotationDamping * Time.deltaTime);

        //Height Position Damping
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        //Convert Angle into Rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngleY, 0);

        //Set Camera Rotation Position
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        //Set Camera Height Position
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        //Look at Target
        transform.LookAt(target);
    }
}
