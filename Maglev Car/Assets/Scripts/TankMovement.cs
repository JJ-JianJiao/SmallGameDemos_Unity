using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public float vInput;
    public float hInput;
    public float rotationSpeed;
    public float forcePower;
    public float antigravForce;
    public float centerDistance;
    public float frontDistance;
    public float backDistance;
    public float leftDistance;
    public float rightDistance;

    Rigidbody rBody;
    RaycastHit centerHit;
    RaycastHit frontHit;
    RaycastHit backHit;
    RaycastHit leftHit;
    RaycastHit rightHit;

    public  GameObject frontRay;
    public  GameObject backRay;
    public  GameObject LeftRay;
    public  GameObject rightRay;
    public Vector3 angles;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        forcePower = 20;
        rotationSpeed = 150.0f;
        centerDistance = 2f;
        antigravForce = 9.81f;
    }

    // Update is called once per frame
    //void Update()
    void Update()
    {
        //vInput = Input.GetAxis("Vertical");
        //hInput = Input.GetAxis("Horizontal");

        //rBody.AddRelativeForce(0, 0, vInput * forcePower);
        //transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * hInput);

        //angles = transform.rotation.eulerAngles;
        //v = rBody.velocity;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {

        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        rBody.AddRelativeForce(0, 0, vInput * forcePower);
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * hInput);

        angles = transform.rotation.eulerAngles;

        //if (Physics.Raycast(transform.position, Vector3.down, out centerHit, centerDistance))
        //if (Physics.BoxCast(transform.position, new Vector3(1.0f,0.50f,2.0f) ,Vector3.down, out centerHit, Quaternion.identity, centerDistance))
        if (Physics.BoxCast(transform.position, new Vector3(1.0f,0.50f,2.0f) ,-transform.up, out centerHit, Quaternion.identity, centerDistance))
        {

            //if ((transform.position.y - 0.5) - (centerHit.transform.position.y + 0.5) >= 1f)
            if ((centerHit.distance -0.5f) >= 1f && (centerHit.distance - 0.5f) <= 1.2f)
            {
                rBody.AddForce(transform.up * antigravForce * rBody.mass);
            }
            //else if ((transform.position.y -0.5) - (centerHit.transform.position.y + 0.5) < 1f)
            else if ((centerHit.distance - 0.5f) < 1f)
            {

                rBody.AddForce(transform.up * antigravForce * 2 * rBody.mass);
            }

            //Debug.Log(centerHit.distance);
            //transform.rotation = centerHit.transform.rotation;

        }

        if (Physics.Raycast(frontRay.transform.position, -transform.up, out frontHit)) {

            //Debug.Log("FrontDistance == " + frontHit.distance + ", gameObject ==" + frontHit.transform);
            frontDistance = frontHit.distance;


        }

        if (Physics.Raycast(backRay.transform.position, -transform.up, out backHit))
        {

            //Debug.Log("backDistance == " + backHit.distance + ", gameObject ==" + backHit.transform);
            backDistance = backHit.distance;
        }


        if (Physics.Raycast(LeftRay.transform.position, -transform.up, out leftHit))
        {

            //Debug.Log("LeftDistance == " + leftHit.distance + ", gameObject ==" + leftHit.transform);
            leftDistance = leftHit.distance;


        }

        if (Physics.Raycast(rightRay.transform.position, -transform.up, out rightHit))
        {

            //Debug.Log("rightDistance == " + rightHit.distance + ", gameObject ==" + rightHit.transform);
            rightDistance = rightHit.distance;
        }


        //if (backDistance - frontDistance > 0.1)
        if (backDistance - frontDistance > 0.1 && (backHit.transform.tag == frontHit.transform.tag) && (backHit.transform.tag == "SteepGround"))
        {
            //Debug.Log("FrontDistance == " + frontHit.distance + ", gameObject ==" + frontHit.transform);
            //Debug.Log("backDistance == " + backHit.distance + ", gameObject ==" + backHit.transform);

            //if (vInput > 0)
            //{
            //    transform.Rotate(transform.right * Time.deltaTime * -100);
            //}
            //else if (vInput < 0) {

            //    transform.Rotate(transform.right * Time.deltaTime * 100);
            //}

            transform.Rotate(Vector3.right * Time.deltaTime * -50);

        }
        //else if (frontDistance - backDistance > 0.1)
        else if (frontDistance - backDistance > 0.1 && (backHit.transform.tag == frontHit.transform.tag) && (backHit.transform.tag == "SteepGround"))
        {
            //Debug.Log("FrontDistance == " + frontHit.distance + ", gameObject ==" + frontHit.transform);
            //Debug.Log("backDistance == " + backHit.distance + ", gameObject ==" + backHit.transform);

            //if (vInput > 0)
            //{
            //    transform.Rotate(transform.right * Time.deltaTime * 100);
            //}
            //else if (vInput < 0)
            //{

            //    transform.Rotate(transform.right * Time.deltaTime * -100);
            //}
            transform.Rotate(Vector3.right * Time.deltaTime * 50);
        }


        //if (leftDistance - rightDistance > 0.1)
        if (leftDistance - rightDistance > 0.1 && (leftHit.transform.tag == rightHit.transform.tag) && (leftHit.transform.tag == "SteepGround"))
        {

            transform.Rotate(Vector3.forward * Time.deltaTime * 50);

        }
        //else if (rightDistance - leftDistance > 0.1)
        else if (rightDistance - leftDistance > 0.1 && (leftHit.transform.tag == rightHit.transform.tag) && (leftHit.transform.tag == "SteepGround"))
        {

            transform.Rotate(Vector3.forward * Time.deltaTime * -50);
        }

        angles = transform.rotation.eulerAngles;


        if ( (frontHit.transform.name == backHit.transform.name) && (frontHit.transform.tag == backHit.transform.tag)) {

            //transform.rotation = Quaternion.Euler(0, angles.y, 0);
            if (frontHit.distance - backHit.distance > 0.1)
            {
                transform.Rotate(Vector3.right * Time.deltaTime * 50);
            }
            else if (backHit.distance - frontHit.distance > 0.1) {

                transform.Rotate(Vector3.right * Time.deltaTime * -50);

            }


            if (leftHit.distance - rightHit.distance > 0.01)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * 50);
            }
            else if (rightHit.distance - leftHit.distance > 0.01)
            {

                transform.Rotate(Vector3.forward * Time.deltaTime * -50);

            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "FlatGround") {

            rBody.AddForce(Vector3.up * antigravForce *4* rBody.mass);
        
        }
    }
}
