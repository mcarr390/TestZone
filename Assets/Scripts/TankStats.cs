using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankStats : MonoBehaviour
{
    public GameObject shield;
    public GameObject sliderHealth;
    public int tankHealth = 100;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider bulletsCollider)
    {
        //lets try to get the Bullet component from whatever collider hit the shield

        Bullet bullet = bulletsCollider.gameObject.GetComponent<Bullet>();
        
        // if we did not get anything than we know whatever hit us is not a bullet;

        bool isWhatHitMeABullet = bullet != null;

        // if a bullet DID hit me
        if (isWhatHitMeABullet && !shield.activeSelf)
        {
            if (bullet.bulletSenderName != gameObject.name)
            {
                
                bullet.ExplodeBullet();
                tankHealth -= 10;
                sliderHealth.GetComponent<Slider>().value = tankHealth;
                if (tankHealth <= 0)
                {
                    Destroy(gameObject);
                }
            }            //explode the bullet as soon as it hits the shield
            
        }
    }
}
