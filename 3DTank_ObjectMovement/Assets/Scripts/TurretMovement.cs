using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{

    float rInput, rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        rInput = Input.GetAxis("Turret");
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * rInput);
    }
}
