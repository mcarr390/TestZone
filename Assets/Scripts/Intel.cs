using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intel : MonoBehaviour
{
    public GameObject chest;
    public bool isSpecial;
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Storage>().intels.Add(this);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        chest.transform.Rotate(Vector3.up, Time.deltaTime * 50f);
    }
}
