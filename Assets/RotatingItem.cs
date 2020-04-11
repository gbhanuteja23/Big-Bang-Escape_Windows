using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItem : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * rotationSpeed, 0));  //Rotating gameobject about y-axis.
        
    }
}
