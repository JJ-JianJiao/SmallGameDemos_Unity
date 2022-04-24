using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankMovement : MonoBehaviour
{

    public float leftTreadInput;
    public float rightTreadInput;
    public float movementSpeed;
    public float movementRate;
    public float rotateRate;
    public float rotationSpeed;
    public float rotateDirection;

    Vector3 moveDirection;

    [SerializeField] Text currentSpeed;
    [SerializeField] Text currentRotate;


    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 6.0f;
        rotationSpeed = 100.0f;
        moveDirection = Vector3.zero;
        movementRate = 0.0f;
        rotateRate = 0.0f;
        rotateDirection = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        leftTreadInput = Input.GetAxis("LeftTreadMove");
        rightTreadInput = Input.GetAxis("RightTreadMove");


        if (leftTreadInput == 1 && rightTreadInput == 1)
        {
            //moveDirection = Vector3.forward;
            //movementRate = 1.0f;

            SetMovement(Vector3.forward, 1.0f);
            SetRotation(0.0f, 0.0f);


            //transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        }
        else if (leftTreadInput == -1 && rightTreadInput == -1)
        {

            //moveDirection = Vector3.back;
            //movementRate = 1.0f;

            SetMovement(Vector3.back, 1.0f);
            SetRotation(0.0f, 0.0f);
            //transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }
        else if ((leftTreadInput == 1 && rightTreadInput == 0) || (leftTreadInput == 0 && rightTreadInput == 1))
        {


            SetMovement(Vector3.forward, 0.5f);

            if (leftTreadInput == 1 && rightTreadInput == 0)
            {
                SetRotation(1.0f, 0.5f);
            }
            else if (leftTreadInput == 0 && rightTreadInput == 1) {

                SetRotation(-1.0f, 0.5f);
            }

            
            //moveDirection = Vector3.forward;
            //movementRate = 0.5f;
            //transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * 0.5f);
        }
        else if ((leftTreadInput == -1 && rightTreadInput == 0) || (leftTreadInput == 0 && rightTreadInput == -1))
        {
            //moveDirection = Vector3.back;
            //movementRate = 0.5f;

            SetMovement(Vector3.back, 0.5f);
            if (leftTreadInput == -1 && rightTreadInput == 0)
            {
                SetRotation(-1.0f, 0.5f);
            }
            else if (leftTreadInput == 0 && rightTreadInput == -1)
            {

                SetRotation(1.0f, 0.5f);
            }
            //transform.Translate(Vector3.back * Time.deltaTime * movementSpeed * 0.5f);
        }
        else if ((leftTreadInput == -1 && rightTreadInput == 1) || (leftTreadInput == 1 && rightTreadInput == -1))
        {
            //moveDirection = Vector3.zero;
            //movementRate = 0.0f;

            SetMovement(Vector3.zero, 0.0f);
            //transform.Translate(Vector3.back * Time.deltaTime * movementSpeed * 0.0f);

            if (rightTreadInput == 1 && leftTreadInput == -1)
            {

                //rotateRate = 1.0f;
                //rotateDirection = -1.0f;

                SetRotation(-1.0f, 1.0f);

            }
            else if (rightTreadInput == -1 && leftTreadInput == 1)
            {
                SetRotation(1.0f, 1.0f);

                //rotateRate = 1.0f;
                //rotateDirection = 1.0f;
            }
        }
        else if (leftTreadInput == 0 && rightTreadInput == 0) {

            //moveDirection = Vector3.zero;
            //movementRate = 0.0f;

            SetMovement(Vector3.zero, 0.0f);
            SetRotation(0.0f, 0.0f);
        }

        DisplayTankStates(movementSpeed * movementRate, rotateRate * rotationSpeed);

        transform.Translate(moveDirection * Time.deltaTime * movementSpeed * movementRate);

        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * rotateRate * rotateDirection);


        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }

    }

    void SetMovement(Vector3 direction, float rate) {

        moveDirection = direction;
        movementRate = rate;
    }

    void SetRotation(float direction, float rate) {

        rotateRate = rate;
        rotateDirection = direction;

    }

    void DisplayTankStates(float speed, float rotate) {

        currentSpeed.text = "Current moving Speed: " + speed;
        currentRotate.text = "Current Rotation Speed: " + rotate;

    }
}
