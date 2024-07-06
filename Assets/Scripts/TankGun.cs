using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TankGun : MonoBehaviour
{
    public GameObject enemyTank;
    
    
    
    
    
    
    
    public GameObject bulletPrefab;
    public Transform muzzle;
    public AudioSource audioSource;
    public List<AudioClip> audioClips;
    public Text ammoText;
    public Storage storage;
    void Start()
    {
        storage = GetComponent<Storage>();
        if (ammoText != null)
        {
            ammoText.text = storage.ammo.ToString();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ammoText != null)
            {
                Fire();

            }
        }
    }

    [ContextMenu("Fire")]
    public void Fire()
    {
        if(storage.ammo == 0)
            return;
        
        var bullet = Instantiate(bulletPrefab, muzzle.position, transform.rotation);
        bullet.GetComponent<Bullet>().attackersName = gameObject.name;
        var randomAudioClip = audioClips[Random.Range(0, audioClips.Count - 1)];
        audioSource.PlayOneShot(randomAudioClip);
        storage.ammo--;
        if (ammoText != null)
        {
            ammoText.text = storage.ammo.ToString();
        }
    }
}
