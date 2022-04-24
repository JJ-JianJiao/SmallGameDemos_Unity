using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsMovement : MonoBehaviour
{

    public float armInput;
    public float armRotateSpeed;
    public Vector3 armsAngles;

    // Start is called before the first frame update
    void Start()
    {
        armRotateSpeed = 150.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        armInput = Input.GetAxis("ArmRotate");

        

        transform.Rotate(Vector3.right * Time.deltaTime * armRotateSpeed * -armInput, Space.Self);

        armsAngles = transform.localRotation.eulerAngles;

        if (armsAngles.x > 25.0f && armsAngles.x <= 90.0f) {

            //transform.rotation = Quaternion.Euler(25.0f, armsAngles.y, armsAngles.z);
            transform.localRotation = Quaternion.Euler(25.0f, 0, 0);

        }
        else if (armsAngles.x < 300.0f && armsAngles.x >= 270.0f)
        {

            //transform.rotation = Quaternion.Euler(300.0f, armsAngles.y, armsAngles.z);
            transform.localRotation = Quaternion.Euler(300.0f, 0, 0);

        }

    }
}
