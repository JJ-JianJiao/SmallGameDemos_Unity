using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderMovement : MonoBehaviour
{

    public float vInput;
    public float hInput;
    public float moveSpeed;
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 6.0f;
        rotationSpeed = 150.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * vInput * moveSpeed);
        transform.Rotate(Vector3.up * Time.deltaTime * hInput * rotationSpeed);


    }
}
