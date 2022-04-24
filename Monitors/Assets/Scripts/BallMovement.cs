using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    Vector3 fallVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ground") {

            this.transform.GetComponent<Rigidbody>().velocity = fallVelocity * -1.05f;
        }
    }


    public void SetVelocity(Vector3 velocity) {

        fallVelocity = velocity;
    }
}
