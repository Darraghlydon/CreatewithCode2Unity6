using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    bool isChasingPlayer = false;
    
    int nextWaypointIndex = 0;
    [SerializeField]
    private Transform[] waypoints = new Transform[2];
    
    private Transform playerTransform;
    private Transform dogTransform;


    private float moveSpeed = 3f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dogTransform = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChasingPlayer)
        {
            HandlePatrolling();
        }
        
    }

    void HandlePatrolling()
    {
        Vector3 distanceToNextWaypoint = waypoints[nextWaypointIndex].position - transform.position;
        if (distanceToNextWaypoint.magnitude < 0.1f)
        {
            nextWaypointIndex = (nextWaypointIndex + 1) % waypoints.Length;
            
        }
        else
        {
            dogTransform.position = Vector3.MoveTowards(dogTransform.position, waypoints[nextWaypointIndex].position,moveSpeed * Time.deltaTime) ;
        }
        
    }
}
