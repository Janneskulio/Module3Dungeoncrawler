using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySecondConTrolled : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject powerup4, healthupsphere;
    [SerializeField] int enemyhp = 0;
    void Start()
    {
        enemyhp = 40;
    }

    void Update()
    {
        secondenemyflipanimation();
    }
    void secondenemyflipanimation()
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
        if(toher.tag == "Player")
        {
            GameConTrolled.instance.health(20);
            Destroy(gameObject);
        }
        if(toher.tag =="bullet")
        { 
            if(powerup4.activeSelf == false)
            {
                Destroy(toher);
                enemyhp -= 20;
            }
            else
            {
                Destroy(toher);
                enemyhp -= 10;
            }
        }
        if(toher.tag == "blast")
        { 
            enemyhp -= 25;
            
        }
        if(enemyhp < 0)
        {
            GameObject healthupobject = Instantiate(healthupsphere, transform.position, Quaternion.identity);     
            GameConTrolled.instance.addScore(10);
            Destroy(gameObject); 
            Destroy(healthupobject, 15); 
        }    
    }
}
