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
    public Text ammoText;
    public Storage storage;
    void Start()
    {
        storage = GetComponent<Storage>();
        ammoText.text = storage.ammo.ToString();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    [ContextMenu("Fire")]
    public void Fire()
    {
        if(storage.ammo == 0)
            return;
        
        var bullet = Instantiate(bulletPrefab, muzzle.position, transform.rotation);
        var randomAudioClip = audioClips[Random.Range(0, audioClips.Count - 1)];
        audioSource.PlayOneShot(randomAudioClip);
        storage.ammo--;
        ammoText.text = storage.ammo.ToString();
    }
}
