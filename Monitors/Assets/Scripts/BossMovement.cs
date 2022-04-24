using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private float bossMovementSpeed;

    public Vector3 bossPosisiton;

    public GameObject bossPositionCenter;
    public GameObject bossPositionCenter2;

    //bool turn;

    // Start is called before the first frame update
    void Start()
    {
        bossMovementSpeed = 2;
        //turn = false;

    }

    // Update is called once per frame
    void Update()
    {
        bossPosisiton = this.transform.localPosition;


        Vector3 newDirection = Vector3.RotateTowards(transform.forward, bossPositionCenter.transform.position - transform.position, 1 * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        this.transform.Translate(Vector3.forward * bossMovementSpeed * Time.deltaTime);

        //if(Pose.)

    }
}
