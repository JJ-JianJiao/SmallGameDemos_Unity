using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlate : MonoBehaviour
{
    public Transform endlocation;
    private Vector3 originalPostion;
    private void Awake()
    {
        originalPostion = transform.position;
    }
    void Start()
    {
        MoveToEnd();

    }

    private void MoveToEnd() {

        LeanTween.move(gameObject, endlocation.position, 5f).setDelay(3.0f).setOnComplete(MoveToStart);
    }

    private void MoveToStart()
    {

        LeanTween.move(gameObject, originalPostion, 5f).setDelay(3.0f).setOnComplete(MoveToEnd);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.transform.SetParent(transform);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.transform.SetParent(null);
        }
    }

}
