using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aoe : MonoBehaviour
{
    public GameObject AoeGameObject;
    
    //accept input from the player 
    //trigger aoe FX 
    //find the enemies hit
    //apply the damage
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isRKeyPressed;
        
        isRKeyPressed = Input.GetKeyDown(KeyCode.R);
        
        
        if ( isRKeyPressed  )
        {
            AoeGameObject.SetActive(false);
            AoeGameObject.SetActive(true);
            Collider[] enemyColliders = Physics.OverlapSphere(gameObject.transform.position, 2f);

            foreach (Collider enemyCollider in enemyColliders)
            {
                if (enemyCollider.gameObject.name.Contains("Enemy"))
                {
                    enemyCollider.gameObject.GetComponent<TankStats>().tankHealth -=5;
                    Debug.Log($"{enemyCollider.gameObject.name}");
                }
                
                
            }
        }
    }
}
