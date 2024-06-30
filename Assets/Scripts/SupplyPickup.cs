using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider colliderThatEnteredMe)
    {
        Debug.Log(colliderThatEnteredMe.gameObject.name);
    }
}
