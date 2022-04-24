using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float vInput, hInput, movementSpeed, rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 6.0f;
        rotationSpeed = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");

        hInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward*Time.deltaTime* movementSpeed*vInput);

        transform.Rotate(Vector3.up*Time.deltaTime*rotationSpeed*hInput);
    }
}
