using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemybulletConTrolled : MonoBehaviour
{
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject toher = other.gameObject;
        if(toher.tag == "Player")
        {
            GameConTrolled.instance.health(10);
            Destroy(gameObject);
        }
        
    }
    void Update()
    {
        
    }
}
