using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string attackersName;
    public string targetName;

    public float speed = 4;
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World); // Use Space.World or Space.Self as needed

    }

    void OnTriggerEnter(Collider colliderThatBulletHit)
    {
        if (colliderThatBulletHit.gameObject.name != attackersName)
        {
            Debug.Log("Bullet hit: " + colliderThatBulletHit.gameObject.name);
            if (colliderThatBulletHit.gameObject.GetComponent<TankStats>() != null)
            {
                colliderThatBulletHit.gameObject.GetComponent<TankStats>().tankHealth -=10;
                if (colliderThatBulletHit.gameObject.GetComponent<TankStats>().tankHealth == 0)
                {
                   Destroy(colliderThatBulletHit.gameObject); 
                }
                

            }
        }
    }
}
