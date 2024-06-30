using UnityEditor;
using UnityEngine;

public class CustomGizmo : MonoBehaviour
{
    public Color gizmoColor = Color.yellow;
    public int perimeterSize = 5; // Perimeter size in units around the game object

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Vector3 position = transform.position;

        // Calculate the grid boundaries around the game object
        int minX = Mathf.FloorToInt(position.x) - perimeterSize;
        int maxX = Mathf.FloorToInt(position.x) + perimeterSize;
        int minZ = Mathf.FloorToInt(position.z) - perimeterSize;
        int maxZ = Mathf.FloorToInt(position.z) + perimeterSize;

        // Draw grid coordinates within the specified perimeter
        for (int x = minX; x <= maxX; x++)
        {
            for (int z = minZ; z <= maxZ; z++)
            {
                Vector3 gridPosition = new Vector3(x, position.y, z);
                //Gizmos.DrawSphere(gridPosition, 0.1f); // Draw a small sphere at each grid coordinate

                // Display coordinate numbers as labels
                Handles.Label(gridPosition + Vector3.up * 0.01f, $"{x},{z}"); // Display coordinates as labels above each sphere
            }
        }
    }
}