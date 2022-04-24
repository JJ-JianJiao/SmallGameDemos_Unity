using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMovement : MonoBehaviour
{

    float timeStamp, movementTime, movementSpeed;

    float delayTime;

    int movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        movementTime = 6.0f;
        movementSpeed = 3.0f;
        movementDirection = 1;

        delayTime = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeStamp + movementTime)
        {

            //Debug.Log(Time.time);
            if (Time.time > timeStamp + delayTime + movementTime)
            {

                movementDirection *= -1;
                timeStamp = Time.time;
                movementSpeed = 3.0f;
            }
            else
            {
                movementSpeed = 0;
            }
        }

        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed * movementDirection);
    }
}
