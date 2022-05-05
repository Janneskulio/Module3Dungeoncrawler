using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiritConTrolled : MonoBehaviour
{
    [SerializeField] GameObject player, healthupsphere;
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
        if(toher.tag == "blast")
        {
            GameObject healthupobject = Instantiate(healthupsphere, transform.position, Quaternion.identity);
            GameConTrolled.instance.addScore(10);
            Destroy(gameObject);
            Destroy(healthupobject, 15);
        }
        if(toher.tag == "Player")
        {
            GameConTrolled.instance.health(30);
            Destroy(gameObject);
        }    
    }
}

