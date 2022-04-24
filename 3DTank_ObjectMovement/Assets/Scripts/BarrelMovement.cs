using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{

    float rInput, rotationSpeed;

    Vector3 angles;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 100.0f;
    }


    // Update is called once per frame
    void Update()
    {
        rInput = Input.GetAxis("Barrel");
        transform.Rotate(Vector3.back, Time.deltaTime * rotationSpeed * rInput);

        angles = transform.localRotation.eulerAngles;
        if (angles.z > 10 && angles.z < 90)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 10.0f);
        }
        if (angles.z < 340 && angles.z > 270)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 340.0f);
        }
    }
}

