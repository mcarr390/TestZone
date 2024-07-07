using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : MonoBehaviour
{
    [FormerlySerializedAs("attackersName")] public string bulletSenderName;
    public string targetName;
    public GameObject explosion;
    public float speed = 4;
    void Update()
    {
        if (!explosion.activeSelf)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World); // Use Space.World or Space.Self as needed
        }
    }
    
    public void ExplodeBullet()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        explosion.SetActive(true);
    }
    
}
