using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public int shieldHealth = 100;
    public GameObject shield;
    void OnTriggerEnter(Collider bulletsCollider)
    {
        //lets try to get the Bullet component from whatever collider hit the shield

        Bullet bullet = bulletsCollider.gameObject.GetComponent<Bullet>();
        
        // if we did not get anything than we know whatever hit us is not a bullet;

        bool isWhatHitMeABullet = bullet != null;

        // if a bullet DID hit me
        if (isWhatHitMeABullet)
        {
            //explode the bullet as soon as it hits the shield
            bullet.ExplodeBullet();
            shieldHealth -= 5;
            shield.GetComponent<Slider>().value = shieldHealth;
            if (shieldHealth <= 0)
            {
                gameObject.SetActive(false);
            }
            
        }
    }
}
