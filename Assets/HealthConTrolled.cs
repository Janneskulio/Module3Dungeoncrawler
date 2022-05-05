using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthConTrolled : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject toher = other.gameObject;
        if(toher.tag == "Player")
        {
            if(GameConTrolled.instance.playerhp <300)
            {
                GameConTrolled.instance.health(-10);
            }
            GameConTrolled.instance.addScore(5);
            Destroy(gameObject);
        }    
    }
}
