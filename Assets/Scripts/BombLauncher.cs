using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign the projectile prefab in the Inspector
    public Transform launchPoint; // Point from where the projectile is launched
    public float launchSpeed = 10f; // Initial launch speed of the projectile
    public float maxHeight = 5f; // Maximum height of the projectile's arc
    public float targetXCoordinate = 10f; // X coordinate where the projectile should land

    void Update()
    {
        // Example: Launch projectile when the player presses a key (e.g., Spacebar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }
    }

    void LaunchProjectile()
    {
        // Instantiate a new projectile object at the launch point's position and rotation
        GameObject projectileInstance = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);

        // Calculate the initial launch direction
        Vector3 launchDirection = CalculateLaunchDirection();

        // Calculate the time of flight using kinematic equations
        float timeOfFlight = CalculateTimeOfFlight(launchDirection);

        // Set the initial velocity using launch speed and launch direction
        Vector3 initialVelocity = launchDirection * launchSpeed;

        // Apply the trajectory manually (without Rigidbody physics)
        projectileInstance.transform.position = launchPoint.position;
        float elapsedTime = 0f;

        while (elapsedTime < timeOfFlight)
        {
            // Calculate height using a quadratic equation (parabola)
            float height = launchPoint.position.y + (maxHeight * Mathf.Sin((Mathf.PI * elapsedTime) / timeOfFlight));

            // Calculate horizontal position
            float horizontalDistance = launchSpeed * elapsedTime * Mathf.Cos((Mathf.PI * elapsedTime) / timeOfFlight);

            // Update projectile position
            Vector3 newPosition = launchPoint.position + launchDirection * horizontalDistance;
            newPosition.y = height;
            projectileInstance.transform.position = newPosition;

            elapsedTime += Time.deltaTime;
        }

        // Ensure the projectile lands exactly at the specified X coordinate
        Vector3 finalPosition = projectileInstance.transform.position;
        finalPosition.x = targetXCoordinate;
        projectileInstance.transform.position = finalPosition;
    }

    Vector3 CalculateLaunchDirection()
    {
        return launchPoint.forward; // Use the forward direction of the launch point for simplicity
    }

    float CalculateTimeOfFlight(Vector3 launchDirection)
    {
        // Calculate the time of flight assuming maximum height is reached halfway through the trajectory
        float timeToMaxHeight = launchSpeed * Mathf.Sin(Mathf.PI / 2) / Physics.gravity.magnitude;
        return 2 * timeToMaxHeight; // Total time of flight for a symmetric arc
    }
}
