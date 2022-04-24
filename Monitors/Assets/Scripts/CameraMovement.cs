using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camRotateSpeed;

    public Vector3 angles;

    //float direction;

    bool changeDirection;

    // Start is called before the first frame update
    void Start()
    {
        //direction = 1.0f;

        changeDirection = false;

        if (transform.name == "TankCam")
        {

            camRotateSpeed = 20.0f;
        }
        else if (transform.name == "BoardCam") {

            camRotateSpeed = 30.0f;
        
        }
        else if (transform.name == "MeetingCam")
        {

            camRotateSpeed = 10.0f;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        angles = transform.localRotation.eulerAngles;
        transform.Rotate(Vector3.up * Time.deltaTime * camRotateSpeed);

        if (angles.y <= 20 && changeDirection == false)
        {

            camRotateSpeed *= -1;
            changeDirection = true;


        }
        else if (angles.y >= 80 && changeDirection == false)
        {
            camRotateSpeed *= -1;
            changeDirection = true;


        }
        else {

            changeDirection = false;
        
        }

        transform.Rotate(Vector3.up * Time.deltaTime * camRotateSpeed );

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }
    }
}
