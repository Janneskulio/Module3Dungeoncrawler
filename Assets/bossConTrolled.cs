using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossConTrolled : MonoBehaviour
{
    [SerializeField] GameObject player, wisp;
    [SerializeField] float wispspeed = 0.0f, wispshootcd = 0.0f;
    [SerializeField] Rigidbody2D wispbody;
    [SerializeField] int bosshp = 1000;
    Animator bossanimator;
    void Start()
    {
        bossanimator = GetComponent<Animator>();
    }
   
    void wispshoot()
    {
        GameObject shootwisps = Instantiate(wisp,transform.position, Quaternion.identity);
        wispbody = shootwisps.GetComponent<Rigidbody2D>();
        wispbody.AddForce((player.transform.position - wispbody.transform.position)
        .normalized * wispspeed);
        Destroy(shootwisps, 2);
    }
    void bossanimationcontroll()
    {
        bossanimator.SetTrigger("Bossidling");
    }
    void bossflipanimation()
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
        if(bosshp < 0)
        {
            var bossbody = gameObject.GetComponent<Rigidbody2D>();
            bossbody.constraints = RigidbodyConstraints2D.FreezePosition;
            bossanimator.SetTrigger("BossDies");
            Destroy(gameObject, 2);
        }
        wispshootcd -= 1 * Time.deltaTime;
        if(wispshootcd < 0)
        {
            if(bosshp >0)
            {
            bossanimator.SetTrigger("BossSpawnWisp");
            Invoke("wispshoot", 0.5f);
            Invoke("wispshoot", 1);
            Invoke("wispshoot", 1.5f);
            Invoke("bossanimationcontroll", 0.5f);
            wispshootcd = 10;
            }
        }
        bossflipanimation();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject toher = other.gameObject;
        if(toher.tag =="Player")
        {            
            
            GameConTrolled.instance.health(30);
            Invoke("bossanimationcontroll",1.5f);    
        } 
        if(toher.tag == "bullet")
        {
            Destroy(toher);
            bosshp -= 20;
        }
    }
    void OnTriggerStay2D(Collider2D other) 
    {
        GameObject toher = other.gameObject;
        if(toher.tag == "Player")
        {
            bossanimator.SetTrigger("Bossattack");
        }    
    }
}
