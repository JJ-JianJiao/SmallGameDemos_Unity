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
        transform.Rotate(Vector3.right, Time.deltaTime * rotationSpeed * rInput);


        angles = transform.localRotation.eulerAngles;
       // Debug.Log(angles.x);

        //transform.localRotation = ClampRotationAroundXAxis(transform.localRotation);


        if (angles.x > 10 && angles.x < 180)
        {
            //transform.rotation = Quaternion.Euler(10.0f, angles.y, angles.z);
            //transform.rotation = Quaternion.Euler(10.0f, 0, 0);
            transform.localRotation = Quaternion.Euler(10.0f, 0, 0);
        }
        if (angles.x < 340 && angles.x > 180)
        {
            //transform.rotation = Quaternion.Euler(340.0f, angles.y, angles.z);
            //transform.rotation = Quaternion.Euler(340.0f, 0, 0);
            transform.localRotation = Quaternion.Euler(340.0f, 0, 0);

        }
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w /= 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -20, 10);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;

    }
}
