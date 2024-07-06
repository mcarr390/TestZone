using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string attackersName;
    public string targetName;
    public GameObject explosion;
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
            bool isTank = colliderThatBulletHit.gameObject.GetComponent<TankStats>() != null;
            if (isTank)
            {

                bool gameObgectHasShield = colliderThatBulletHit.gameObject.name == "Shield";
                if (!gameObgectHasShield)
                {
                    colliderThatBulletHit.gameObject.GetComponent<TankStats>().tankHealth -=10;
                    bool tankHealthBelowZero = colliderThatBulletHit.gameObject.GetComponent<TankStats>().tankHealth <= 0;
                    if (tankHealthBelowZero)
                    {
                        DestroyTank(colliderThatBulletHit);
                    }
                }

            }
            else
            {
                bool gameObgectHasShield = colliderThatBulletHit.gameObject.name == "Shield";
                if (gameObgectHasShield)
                {
                    ExplodeBullet();
                } 
            }
        }
    }

    private void ExplodeBullet()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        explosion.SetActive(true);
    }

    private static void DestroyTank(Collider colliderThatBulletHit)
    {
        Destroy(colliderThatBulletHit.gameObject);
    }
}
