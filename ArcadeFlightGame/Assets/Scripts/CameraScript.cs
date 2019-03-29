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
    public float rotationDamping = 3.0f;

    void LateUpdate()
    {
        //If target isn't set, return
        if(!target)
            return;

        //Rotation Variables
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        //Y-Axis Rotation Damping
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        //High Damping
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        //Convert Angle into Rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        //Set Camera Position
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        //Set Camera Height
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        //Look at Target
        transform.LookAt(target);
    }
}
