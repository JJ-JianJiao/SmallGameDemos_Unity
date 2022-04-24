using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInView : MonoBehaviour
{


    [SerializeField]
    float xInput, yInput, zInput, movementSpeed;
    [SerializeField] Vector3 pos, objSize;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime, 0));

        pos = Camera.main.WorldToViewportPoint(transform.position);
        objSize = (GetComponent<Collider>().bounds.extents);
        objSize = (GetComponent<Collider>().bounds.extents) / 10;
        pos.x = Mathf.Clamp(pos.x, objSize.x, 1 - objSize.x);
        pos.y = Mathf.Clamp(pos.y, objSize.y, 1 - objSize.y);

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
