using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider colliderThatEnteredMe)
    {
        Storage storage = colliderThatEnteredMe.gameObject.GetComponent<Storage>();
        storage.ammo = 10;
        Debug.Log(colliderThatEnteredMe.gameObject.name);
    }
}
