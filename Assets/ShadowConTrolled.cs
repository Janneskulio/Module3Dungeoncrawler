using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowConTrolled : MonoBehaviour
{
   [SerializeField] GameObject player;
    void Start()
    {
        
    }
    void Update()
    {
        shadowenemyflipanimation();
    }
    void shadowenemyflipanimation()
    {
        var enemysprite = gameObject.GetComponent<SpriteRenderer>();
        if(player.transform.position.x < transform.position.x)
        {
            enemysprite.flipX = true;
        }
        if(player.transform.position.x > transform.position.x)
        {
            enemysprite.flipX = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject toher = other.gameObject;
         
    }
}
