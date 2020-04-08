using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    public Transform playerTransform;   // To transform the player

    private Vector3 cameraOffset;       // Camera Offset value
    
    [Range(0.01f,1.0f)]
    public float smoothFactor = 0.5f;         // Smoothness actor of camera

    public bool LookAtPlayer = true;    //variable which stores whether camera is looking at player or not.

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;   //Calculating Camera Offset
        
    }

    //Late Update is called after Update() methods
    void LateUpdate()
    {
        Vector3 newPos = playerTransform.position + cameraOffset;  //New position of player

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);  //Interpolating between two coordinates

        if(LookAtPlayer)                   //  whether camera is looking at player or not.
        {
            transform.LookAt(playerTransform);
        }
        
    }
}
