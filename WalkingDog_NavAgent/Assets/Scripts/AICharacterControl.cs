using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterControl : MonoBehaviour
{
    [SerializeField]
    private Transform positonA;
    private NavMeshAgent meshAgent;

    RaycastHit hit = new RaycastHit();
    public bool underControl = false;
    public bool isPatrol = false;
    public Transform[] points;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();

        if (isPatrol) {
            meshAgent.autoBraking = false;
            GoToNextPoint();
        }
    }

    private void GoToNextPoint()
    {
        if (points.Length == 0) {
            return;
        }

        meshAgent.destination = points[destPoint].position;

        destPoint = (++destPoint) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (positonA != null)
        {
            meshAgent.destination = positonA.position;
        }

        if (isPatrol)
        {
            if (!meshAgent.pathPending && meshAgent.remainingDistance < 0.5f) {
                GoToNextPoint();
            }
        }

        if (underControl) {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100)) {
                    meshAgent.destination = hit.point;
                }
            }
        }


    }
}
