using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    float rotationSpeed;

    float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position;
        mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime * rotationSpeed);
    }
}
