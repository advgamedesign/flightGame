using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript_OLD : MonoBehaviour

{
    public Transform targetPlayer;
    public Vector3 distance = new Vector3(0f,5f,-10f);

    public float positionDamping = 2.0f;
    public float rotationDamping = 2.0f;

    private Transform thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Check to see if a target has been assigned
        if (targetPlayer == null)
        {
            return;
        }

        Vector3 wantedPosition = targetPlayer.position + (targetPlayer.rotation * distance);
        Vector3 currentPosition = Vector3.Lerp(thisTransform.position, wantedPosition, positionDamping * Time.deltaTime);
        thisTransform .position = currentPosition;

        Quaternion wantedRotation = Quaternion.LookRotation(targetPlayer.position - thisTransform.position, targetPlayer.up);

        thisTransform.rotation = wantedRotation;

    
    }
}
