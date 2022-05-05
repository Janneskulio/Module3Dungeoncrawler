using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyConTrolled : MonoBehaviour
{

    [SerializeField] int hp = 0;
    [SerializeField] GameObject enemybullet, powerup4;
    [SerializeField] Rigidbody2D enemybulletbody;
    [SerializeField] GameObject player;
    [SerializeField] float shootcd = 0.0f;
    [SerializeField] float bulletspeed = 0.0f;
    [SerializeField] GameObject healthupsphere;
    float move_x,move_y;
    void Start()
    {
        hp = 50;
    }
    void enemyshooting()
    {
        var location = transform.position;
        GameObject enemyshoot = Instantiate(enemybullet, location, Quaternion.identity);
        enemybulletbody = enemyshoot.GetComponent<Rigidbody2D>();
        enemybulletbody.AddForce((player.transform.position - transform.position)
        .normalized * bulletspeed);
        enemyshoot.transform.right = player.transform.position - transform.position;
        Destroy(enemyshoot, 3);
    }
    void enemyflipanimation()
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
    void Update()
    {
        enemyflipanimation();
    }
    void FixedUpdate()
    {
        shootcd -= 1 * Time.fixedDeltaTime;
        var distbetween = Vector3.Distance(player.transform.position, transform.position);
        if(distbetween < 5)
        {
            if(shootcd < 0)
            {
                enemyshooting();
                shootcd = 1.5f;            
            }

        }
          
    }
    void OnTriggerEnter2D(Collider2D other)     
    {
       
        GameObject toher = other.gameObject;
        if(toher.tag =="bullet")
        { 
            if(powerup4.activeSelf == false)
            {
                Destroy(toher);
                hp -= 20;
            }
            else
            {
                Destroy(toher);
                hp -= 10;
            }
        }
        if(toher.tag == "blast")
        { 
            hp -= 25;
            
        }
        if(hp < 0)
        {
            GameObject healthupobject = Instantiate(healthupsphere, transform.position, Quaternion.identity);     
            GameConTrolled.instance.addScore(10);
            Destroy(gameObject);  
            Destroy(healthupobject, 15);
        }
       
    } 
   
}
