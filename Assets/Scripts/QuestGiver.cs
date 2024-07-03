using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    void OnTriggerEnter(Collider colliderThatEnteredMe)
    {
        GameObject myGameObject = gameObject;
        Intel questGiversintel = gameObject.GetComponent<Intel>();
        Storage playersStorage = colliderThatEnteredMe.gameObject.GetComponent<Storage>();
        playersStorage.intel = questGiversintel;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
