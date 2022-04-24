using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlCam : MonoBehaviour
{
    public float vInput;

    public float hInput;

    public float rotationSpeed;

    public float movementSpeed;

    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 100.0f;
        movementSpeed = 3.0f;


    }

    // Update is called once per frame
    void Update()
    {
        position = this.transform.position;

        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");


        this.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * hInput);

        if ( (position.y < 2 && vInput <0) || (position.y > 5 && vInput > 0))
        {

            movementSpeed = 0;

        }
        else {

            movementSpeed = 3;
        
        }


        this.transform.Translate(Vector3.up * Time.deltaTime * movementSpeed * vInput);

    }
}
