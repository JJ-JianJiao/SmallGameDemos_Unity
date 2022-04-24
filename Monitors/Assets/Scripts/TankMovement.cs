using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    float vInput, hInput, movementSpeed, rotationSpeed;

    [SerializeField] Vector3 pos, objSize;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        rotationSpeed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * vInput);

        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * hInput);

        pos = Camera.main.WorldToViewportPoint(transform.position);
        objSize = (GetComponent<Collider>().bounds.extents);
        objSize = (GetComponent<Collider>().bounds.extents) / 10;
        pos.x = Mathf.Clamp(pos.x, objSize.x, 1 - objSize.x);
        pos.y = Mathf.Clamp(pos.y, objSize.y, 1 - objSize.y);

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
