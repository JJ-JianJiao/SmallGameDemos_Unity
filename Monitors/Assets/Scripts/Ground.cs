using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {

            other.transform.GetComponent<BallMovement>().SendMessage("SetVelocity", other.transform.GetComponent<Rigidbody>().velocity);

        }
    }

}
