using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject camSpot;

    float rotationSpeed = 200.0f;
    float mouseX;

    void Update()
    {
        transform.position = player.transform.position;
        //cam.transform.LookAt(player.transform);
        if (Input.GetMouseButton(1))
        {
            mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up, mouseX * Time.deltaTime * rotationSpeed);
        }
    }
}
