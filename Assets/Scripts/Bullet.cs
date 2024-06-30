using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4;
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World); // Use Space.World or Space.Self as needed

    }

    void OnTriggerEnter(Collider colliderThatBulletHit)
    {
        if (colliderThatBulletHit.gameObject.name != "PlayerTank")
        {
            Debug.Log("Bullet hit: " + colliderThatBulletHit.gameObject.name);

        }
    }
}
