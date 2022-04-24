using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketMovement : MonoBehaviour
{

    public float bucketInput;
    public float bucketRotateSpeed;
    public Vector3 bucketAngles;

    // Start is called before the first frame update
    void Start()
    {
        bucketRotateSpeed = 100.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bucketInput = Input.GetAxis("BucketRotate");
        transform.Rotate(Vector3.right * Time.deltaTime * bucketRotateSpeed * -bucketInput, Space.Self);


        bucketAngles = transform.localRotation.eulerAngles;
        if (bucketAngles.x >= 71.0f && bucketAngles.x <= 90.0f)
        {

            transform.localRotation = Quaternion.Euler(70.0f, 0, 0);

        }
        else if (bucketAngles.x < 320.0f && bucketAngles.x >= 270.0f)
        {

            transform.localRotation = Quaternion.Euler(320.0f, 0, 0);

        }
    }


    private void OnTriggerEnter(Collider stuff)
    {
        if (stuff.transform.tag == "Stuff") {

            //Debug.Log("Get Stuff");

            stuff.transform.parent = transform;

        }
    }

    private void OnTriggerExit(Collider stuff)
    {
        if (stuff.transform.tag == "Stuff")
        {

            //Debug.Log("Get Stuff");

            stuff.transform.parent = null;

        }
    }
}
