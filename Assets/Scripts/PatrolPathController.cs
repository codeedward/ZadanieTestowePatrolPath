using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolPathController : MonoBehaviour
{
    public List<Transform> Points;
    public float Treshold;
    private int currentPointIndex = -1;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        UpdateTarget();
    }

    void Update()
    {
        CheckDestinationReached();
    }

    public Transform GetNextPoint()
    {
        if(++currentPointIndex >= Points.Count)
        {
            currentPointIndex = 0;
        }
        return Points[currentPointIndex];
    }

    void SetNextPoint(ref Transform point)
    {
        agent.destination = point.position;
    }

    void UpdateTarget()
    {
        var nextPoint = GetNextPoint();
        SetNextPoint(ref nextPoint);
    }

    void CheckDestinationReached() 
    {
        float distanceToTarget = Vector3.Distance(transform.position, Points[currentPointIndex].position);
        if(distanceToTarget < Treshold)
        {
            UpdateTarget();
        }
    }
}