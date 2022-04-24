using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float hInput;
    float vInput;
    float movementSpeed;
    //float rotationSpeed;

    public Vector3 direction;
    public Vector3 direction2;

    public Vector3 newDirection;

    [SerializeField]
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        //rotationSpeed = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        direction = new Vector3(hInput * Time.deltaTime * movementSpeed, 0, vInput * Time.deltaTime * movementSpeed);



        direction2 = cam.transform.TransformDirection(direction);

        //transform.Translate(cam.transform.TransformDirection(direction), Space.World);



        newDirection = Vector3.RotateTowards(transform.forward, cam.transform.TransformDirection(direction), movementSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

    }
}
