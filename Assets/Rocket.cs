using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;    // declaring variable rigidBody of type RigidBody data type. 

    AudioSource rocketSound;   //declaring variable rocketSound of type AudioSource


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();       //GetComponent is a functions which fetches RigidBodies here

        rocketSound = GetComponent<AudioSource>();   //Getcomponent fetches AudioSource to play
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
    }

                          // Unity uses left handed system, this means pressing A turns anti-clockwise
                          //and pressing D, turns clockwise direction

                                     //Vector3 is a struct which stores the coordinates of the bodies
    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))    //Read about Input.GetKey() from the concepts of C# folder
        {
            rigidBody.AddRelativeForce(Vector3.up);          // Press Space for Thrusting the rocket upwards

            if(!rocketSound.isPlaying)  //If rocketSound is not playing then play else not, so as to not repeat it.
            {
                rocketSound.Play();    //To play the audio source when Space is pressed
            }
            
        }

        else
        {
            rocketSound.Stop();   // To stop playing rocketSound
        }


        if (Input.GetKey(KeyCode.A))   //KeyCode is an enum where all the key values of keyboard are stored
        {
            transform.Rotate(Vector3.forward);     //To rotate the rocket (-z axis) direction
                                                  //anti-clockwise direction rotation
                                                  // forward corresponds to z axis in unity
        }

        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);   //To rotate in clockwise direction (+z axis)
           
        }
        
    }
   
}
