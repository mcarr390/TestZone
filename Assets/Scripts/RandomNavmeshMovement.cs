using UnityEngine;
using UnityEngine.AI;

public class RandomNavmeshMovement : MonoBehaviour
{
    public float wanderRadius = 20f; // Maximum distance to wander from the starting point
    private Vector3 startingPosition; // Starting position of the GameObject
    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    public float timeDelayBetweenMovements = 30f;
    public float timeSinceMovementStart = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startingPosition = transform.position;

        // Start wandering immediately
        Wander();
    }

    void Update()
    {
        // If the agent has reached the destination or is stuck, wander again
        bool finishedPath = !agent.pathPending && agent.remainingDistance < 0.1f;
        
        if (finishedPath && timeSinceMovementStart > timeDelayBetweenMovements)
        {
            timeSinceMovementStart = 0f;
            Wander();
        }
        else
        {
            timeSinceMovementStart += Time.deltaTime;
        }
    }

    void Wander()
    {
        // Generate a random direction and distance within the wander radius
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += startingPosition;
        NavMeshHit navHit;

        // Find a point on the NavMesh within the random direction
        NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, NavMesh.AllAreas);

        // Set the destination for the NavMeshAgent to the random point
        agent.SetDestination(navHit.position);
    }
}