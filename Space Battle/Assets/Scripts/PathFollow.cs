using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform tWaypoint;
    private int tWaypointIndex = 0;
    private float minDis = 0.1f;
    private int lasttWaypointIndex;

    public float Speed;
    public float rotationSpeed;
    void Start()
    {
        lasttWaypointIndex = waypoints.Count - 1;
        tWaypoint = waypoints[tWaypointIndex];
    }


    void Update()
    {
        float movementDistance = Speed * Time.deltaTime;
        float rotationDistance = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = tWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationDistance);

        float distance = Vector3.Distance(transform.position, tWaypoint.position);
        CheckDistancetoWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, tWaypoint.position, movementDistance);
    }

    void CheckDistancetoWaypoint(float currentDistance)
    {
        if (currentDistance <= minDis)
        {
            tWaypointIndex++;
            UpdateTargetWaypoint();
        }



    }

    void UpdateTargetWaypoint()
    {
        if (tWaypointIndex > lasttWaypointIndex)
        {
            tWaypointIndex = 0;
        }
        tWaypoint = waypoints[tWaypointIndex];
    }
}
