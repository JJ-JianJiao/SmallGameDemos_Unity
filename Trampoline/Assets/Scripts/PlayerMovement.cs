using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{
    public GameObject cubeStablePosition;
    public GameObject cubeFallPosition; 
    
    public GameObject playerViewPosition;
    public GameObject playJumpPosition;
    public GameObject cube;

    // Input Variables
    float hInput, vInput, cInput;


    // Movement Variables
    float movementSpeed, rotationSpeed, clampRotationSpeed;

    Camera playerCam;

    Vector3 angles;




    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        rotationSpeed = 100.0f;
        clampRotationSpeed = 300.0f;
        playerCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        cInput = Input.GetAxis("Mouse Y");


        transform.Translate(Vector3.forward * vInput * Time.deltaTime * movementSpeed);
        transform.Rotate(Vector3.up, hInput * Time.deltaTime * rotationSpeed);
        playerCam.transform.Rotate(Vector3.right, -cInput * Time.deltaTime * clampRotationSpeed);
        angles = playerCam.transform.eulerAngles;

        if (angles.x > 70.0f && angles.x < 90)
        {
            //angles.x = 45.0f;
            angles.x = 70.0f;
        }
        if (angles.x < 315.0f && angles.x > 270)
        {
            angles.x = 315.0f;
        }
        playerCam.transform.rotation = Quaternion.Euler(angles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        if (Input.GetKeyDown(KeyCode.R)) {

            transform.position = playJumpPosition.transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 90f, transform.rotation.z);
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

            cube.transform.position = cubeStablePosition.transform.position;
            cube.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
        if (Input.GetKeyDown(KeyCode.F))
        {

            transform.position = playerViewPosition.transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

            cube.transform.position = cubeFallPosition.transform.position;
            cube.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }

    }

}
