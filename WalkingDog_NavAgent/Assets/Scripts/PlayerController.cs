using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float hInput;
    private float vInput;
    public float moveSpeed;
    public float rotateSpeed;

    public Vector3 direction;
    public Vector3 transferDirection;

 

    [SerializeField]
    GameObject cam;

    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private void Movement()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        //transform.Translate(hInput * moveSpeed * Time.deltaTime, 0, vInput * moveSpeed * Time.deltaTime);
        //transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed*vInput);
        //transform.Rotate(Vector3.up * hInput * Time.deltaTime* rotateSpeed);

        direction = new Vector3(hInput * Time.deltaTime * moveSpeed, 0, vInput * Time.deltaTime * moveSpeed);
        transferDirection = cam.transform.TransformDirection(direction);
        Debug.Log(direction);
        Debug.Log(transferDirection);
        transform.Translate(transferDirection, Space.World);

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, cam.transform.TransformDirection(direction), rotateSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
