using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Trampoline : MonoBehaviour
{

    public float boxRayDistance;

    RaycastHit hit;

    public  Vector3 oldVelocity;

    public float jumperRange;

    bool playerJump;

    // Start is called before the first frame update
    void Start()
    {
        boxRayDistance = 3f;
        oldVelocity = Vector3.zero;
        jumperRange = 1;
        playerJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.BoxCast(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2), Vector3.up, out hit, Quaternion.identity, boxRayDistance))
        {

            Rigidbody hitObjRb = hit.transform.GetComponent<Rigidbody>();
            //Debug.Log("Obj.Velocity = " + hitObjRb.velocity);
            oldVelocity = hitObjRb.velocity;

            if (Input.GetKeyDown(KeyCode.Space) && hit.transform.name == "Player") {

                //playerJump = true;
                //if (hit.transform.GetComponent<Rigidbody>().velocity.y <= 0 && hit.transform.GetComponent<Rigidbody>().velocity.y >= -5) {

                //    hit.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
                
                //} 
                if(hit.transform.position.y - transform.position.y <= 2) { 
                    playerJump = true;
                }

                if (hit.transform.GetComponent<Rigidbody>().velocity.y <= 0 && hit.transform.GetComponent<Rigidbody>().velocity.y >= -3.0f) {

                    hit.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
                    playerJump = false;
                    Debug.Log("Zore to Jump");
                
                }

            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 objectVelocity = collision.rigidbody.velocity;
        //Debug.Log("Hahaha");
        //Debug.Log("oldVelocity.y = " + oldVelocity.y);
        if (playerJump == false)
        {
            collision.rigidbody.velocity = new Vector3(objectVelocity.x, oldVelocity.y * -0.8f, objectVelocity.z);
            Debug.Log("No Space");
        }
        else
        {
            collision.rigidbody.velocity = new Vector3(objectVelocity.x, oldVelocity.y * -1.2f, objectVelocity.z);
            playerJump = false;
            Debug.Log("Jumper Higher");
        }

        //collision.rigidbody.velocity = new Vector3(oldVelocity.x, 12.2f, oldVelocity.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawCube(transform.position, new Vector3(transform.localScale.x , transform.localScale.y , transform.localScale.z ));
    }
}
