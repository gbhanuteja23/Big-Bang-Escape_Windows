using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;    // declaring variable rigidBody of type RigidBody data type. 

    AudioSource rocketSound;   //declaring variable rocketSound of type AudioSource

    [SerializeField] float rcsThrust = 100f;   //f states that 100 is a floating no.  rcs stands for rection control system
                                               //variable to control speed of rocket

    //Serializing private field lets you control it in Unity Inspector

    [SerializeField] float mainThrust = 100f;   //mainThrust variable to change the thrust of ship depending on it's mass

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();       //GetComponent is a functions which fetches RigidBodies here

        rocketSound = GetComponent<AudioSource>();   //Getcomponent fetches AudioSource to play
        
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();          // Function which handles thrusting of rocket

        Rotate();            //Function which handles rotation of rocket
        
    }
                                      // Unity uses left handed system, this means pressing A turns anti-clockwise
                                     //and pressing D, turns clockwise direction

                                     //Vector3 is a struct which stores the coordinates of the bodies

    private void Rotate()       //Function which handles rotation of rocket
    {        
        rigidBody.freezeRotation = true; // freezing the rotaton to control the ship manually

        float rotateThisFrame = rcsThrust * Time.deltaTime;    //Time.deltatime provides the time b/w current and previous frame

        if (Input.GetKey(KeyCode.A))   //KeyCode is an enum where all the key values of keyboard are stored
        {           
            transform.Rotate(Vector3.forward*rotateThisFrame);     //To rotate the rocket in anti-clockwise direction (-z axis)                                   
                                                                // forward corresponds to z axis in unity
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward*rotateThisFrame);   //To rotate in clockwise direction (+z axis)

        }


        else if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-new Vector3(0,1,0) * rotateThisFrame);   //To rotate in clockwise direction (+y axis)

        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotateThisFrame);   //To rotate in anti-clockwise direction (-y axis)

        }

        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-new Vector3(1, 0, 0) * rotateThisFrame);   //To rotate in clockwise direction (+x axis)

        }

        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(1, 0, 0) * rotateThisFrame);   //To rotate in clockwise direction (-x axis)

        }


        rigidBody.freezeRotation = false;   //To resume physics(automatic) simulation of rotation
    }


    private void Thrust()           // Function which handles thrusting of rocket
    {
        if (Input.GetKey(KeyCode.Space))    //Read about Input.GetKey() from the concepts of C# folder
        {
            rigidBody.AddRelativeForce(Vector3.up*mainThrust);          // Press Space for Thrusting the rocket upwards

            if (!rocketSound.isPlaying)  //If rocketSound is not playing then play else not, so as to not repeat it.
            {
                rocketSound.Play();    //To play the audio source when Space is pressed
            }

        }

        else if (Input.GetKey(KeyCode.LeftControl))    //Read about Input.GetKey() from the concepts of C# folder
        {
            rigidBody.AddRelativeForce(Vector3.down * mainThrust);       // Press left control for Thrusting the rocket downwards

            if (!rocketSound.isPlaying)  //If rocketSound is not playing then play else not, so as to not repeat it.
            {
                rocketSound.Play();    //To play the audio source when Space is pressed
            }

        }

        else if (Input.GetKey(KeyCode.UpArrow))    //Read about Input.GetKey() from the concepts of C# folder
        {
            rigidBody.AddRelativeForce(new Vector3(0,0,1) * mainThrust);          // Press Up Arrow(↑) for Thrusting the rocket forward (+z axis)

            if (!rocketSound.isPlaying)  //If rocketSound is not playing then play else not, so as to not repeat it.
            {
                rocketSound.Play();    //To play the audio source when Space is pressed
            }

        }

        else if (Input.GetKey(KeyCode.DownArrow))    //Read about Input.GetKey() from the concepts of C# folder
        {
            rigidBody.AddRelativeForce(new Vector3(0, 0, -1) * mainThrust);          // Press down Arrow(↓) for Thrusting the rocket backward (-z axis)

            if (!rocketSound.isPlaying)  //If rocketSound is not playing then play else not, so as to not repeat it.
            {
                rocketSound.Play();    //To play the audio source when Space is pressed
            }

        }

        else
        {
            rocketSound.Stop();   // To stop playing rocketSound
        }
    }
}
