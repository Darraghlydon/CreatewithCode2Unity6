using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    bool isChasingPlayer = false;
    
    int nextWaypointIndex = 0;
    [SerializeField]
    private Transform[] waypoints = new Transform[2];
    
    [SerializeField]
    private Transform playerTransform;
    private Transform dogTransform;
    private AudioSource dogAudioSource;


    private float moveSpeed = 3f; 
    private float chaseSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dogTransform = transform;
        dogAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChasingPlayer)
        {
            HandlePatrolling();
            
        }
        else
        {
            HandleChasing();
        }

      HandleVision();

    }

    void HandlePatrolling()
    {
        Vector3 distanceToNextWaypoint = waypoints[nextWaypointIndex].position - transform.position;
        if (distanceToNextWaypoint.magnitude < 0.1f)
        {
            nextWaypointIndex = (nextWaypointIndex + 1) % waypoints.Length;
            dogTransform.forward = waypoints[nextWaypointIndex].position - dogTransform.position;
            
        }
        else
        {
            dogTransform.position = Vector3.MoveTowards(dogTransform.position, waypoints[nextWaypointIndex].position,moveSpeed * Time.deltaTime) ;
        }
        
    }

    void HandleVision()
    {
        Vector3 dogForwardVector = dogTransform.forward.normalized;
        
        Vector3 playerVector = (playerTransform.position - transform.position);
        if (playerVector.sqrMagnitude < 75)
        {
            float dotProduct = Vector3.Dot(dogForwardVector, playerVector.normalized);
            if (dotProduct > 0.95f)
            {
                isChasingPlayer = true;
                if(!dogAudioSource.isPlaying)
                {
                    dogAudioSource.Play();
                }
                    
                    
                
            }
            else
            {
              StopChasing();
            }
        }
        else
        {
            StopChasing();
        }
    }

    void HandleChasing()
    {
        
        dogTransform.position = Vector3.MoveTowards(dogTransform.position, playerTransform.position,chaseSpeed * Time.deltaTime) ;
        dogTransform.forward = playerTransform.position - dogTransform.position;
        
    }

    

    void StopChasing()
    {
        isChasingPlayer = false;
        dogAudioSource.Stop();
        dogTransform.forward = waypoints[nextWaypointIndex].position - dogTransform.position;
    }
}
