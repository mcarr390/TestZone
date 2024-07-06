using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public TankStats stats;
    public Transform target; // The target object to follow
    public Transform cameraTransform; // The camera to face
    private Quaternion initialRotation; // The initial rotation of the canvas

    void Start()
    {
        if (target == null)
        {
            target = transform.parent; // Default to parent object if no target specified
        }

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // Default to the main camera if no camera specified
        }

        // Store the initial rotation of the canvas
        initialRotation = transform.rotation;
    }

    void Update()
    {
        healthBar.value = stats.tankHealth;
    }

    void LateUpdate()
    {
        // Follow the position of the target object
        transform.position = target.position + Vector3.up + (Vector3.right * .3f);

        // Always face the camera
        transform.LookAt(cameraTransform);

        // Reset to the initial rotation around the forward axis to maintain the initial editor rotation
        transform.rotation = Quaternion.LookRotation(cameraTransform.forward, initialRotation * Vector3.up);
    }
}
