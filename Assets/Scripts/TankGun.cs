using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TankGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;
    public AudioSource audioSource;
    public List<AudioClip> audioClips;
    public int ammo = 2;
    public Text ammoText;

    void Start()
    {
        ammoText.text = ammo.ToString();

    }

    [ContextMenu("Fire")]
    public void Fire()
    {
        if(ammo == 0)
            return;
        
        var bullet = Instantiate(bulletPrefab, muzzle.position, transform.rotation);
        var randomAudioClip = audioClips[Random.Range(0, audioClips.Count - 1)];
        audioSource.PlayOneShot(randomAudioClip);
        ammo--;
        ammoText.text = ammo.ToString();
    }
}
