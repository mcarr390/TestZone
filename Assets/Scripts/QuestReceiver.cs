using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReceiver: MonoBehaviour
{
    void OnTriggerEnter(Collider colliderThatEnteredMe)
    {
        List<Intel> intelsPlayerWasCarrying;
        intelsPlayerWasCarrying = colliderThatEnteredMe.gameObject.GetComponent<Storage>().intels;


        foreach (Intel intel in intelsPlayerWasCarrying)
        {
            if (intel.isSpecial)
            {
               Debug.Log("congratulations"); 
            }
        }
        // Intel intel = colliderThatEnteredMe.gameObject.GetComponent <Storage>().intels;
        // bool isIntelValid = intel == null;
        //
        // if (isIntelValid)
        // {
        //     colliderThatEnteredMe.gameObject.GetComponent<Storage>().gold+=1000;
        //     Debug.Log("Mission Complete");
        // }


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