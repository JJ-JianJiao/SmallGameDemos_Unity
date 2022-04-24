using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRoateMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.name == "RotateX")
        {
            this.transform.Rotate(Vector3.right * 100 * Time.deltaTime);
        }
        else if (transform.name == "Rotate-X")
        {
            this.transform.Rotate(Vector3.right * -100 * Time.deltaTime);
        }
        else if (transform.name == "RotateZ")
        {
            this.transform.Rotate(Vector3.forward * -100 * Time.deltaTime);
        }
        else if (transform.name == "RotateY")
        {
            this.transform.Rotate(Vector3.up * -100 * Time.deltaTime);
        }
    }
}
