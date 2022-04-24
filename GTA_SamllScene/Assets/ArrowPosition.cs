using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPosition : MonoBehaviour
{
    [SerializeField]
    private Transform play;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(new Vector3(play.position.x, gameObject.transform.position.y, play.position.z));
    }
}
