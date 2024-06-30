using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    float _movementSpeed = 1;
    float _rotationSpeed = 50;
    void Update()
    {
        transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * _movementSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime);
    }
}
