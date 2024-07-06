using UnityEngine;
using UnityEngine.AI;

public class EnemyTankAI : MonoBehaviour
{
    public Transform playerTank; // Reference to the player's tank
    public float detectionRange = 20f; // Distance at which the enemy detects the player
    public float firingRange = 5f; // Distance at which the enemy can fire
    public float wanderRadius = 10f; // Radius for wandering
    public float wanderTimer = 5f; // Time to switch to a new wander point
    public float firingCooldown = 2f; // Cooldown time between shots

    private NavMeshAgent agent;
    private float timer;
    private float lastFiredTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        lastFiredTime = -firingCooldown; // Initialize to allow immediate firing
    }

    void Update()
    {
        timer += Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTank.position);

        if (distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer <= firingRange)
            {
                // Stop the tank and attempt to fire at the player
                agent.isStopped = true;
                FireAtPlayer();
            }
            else
            {
                // Resume chasing the player
                agent.isStopped = false;
                agent.SetDestination(playerTank.position);
            }
        }
        else
        {
            // Wander around
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
    }

    Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    void FireAtPlayer()
    {
        if (Time.time >= lastFiredTime + firingCooldown)
        {
            // Implement your firing mechanism here
            transform.LookAt(playerTank);
            GetComponent<TankGun>().Fire();
            lastFiredTime = Time.time; // Update the last fired time
        }
    }
}
