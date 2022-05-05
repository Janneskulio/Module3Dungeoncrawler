using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerConTrolled : MonoBehaviour
{
    [SerializeField] Rigidbody2D movement, blastbody;
    [SerializeField] float nopeus = 0.0f, dashnopeus = 0.0f, sprinting = 0.0f;
    [SerializeField] GameObject arrow, blast;
    [SerializeField] Rigidbody2D arrowbody;
    [SerializeField] float arrowspeed = 0.0f, blastspeed = 0.0f;
    [SerializeField] float shootcd = 0.0f, dashcd = 0.0f;
    [SerializeField] float blastaroundtime = 0.0f;
    [SerializeField] GameObject powerup, powerup1, powerup2, powerup3, powerup4, 
    speedpowerup, healthupsphere;
    [SerializeField] Slider dashcooldownslide, blastcooldownslider, staminaslider;
    [SerializeField] Text poweruptext;
    [SerializeField] int powerupamount = 0;
    Animator playeranimator;
    Vector2 playerinput;
    float move_x, move_y;
    public string state = "idle";    
    void Start()
    {
        sprinting = 10;
        blastaroundtime = 3;
        dashcd = 5;
        playeranimator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject toher = other.gameObject;
        if(toher.tag == "powerup")
        {
            powerup.SetActive(false);
            powerupamount += 1;
        }
        if(toher.tag == "powerup1")
        {
            powerup1.SetActive(false);
            powerupamount += 1;
        }
        if(toher.tag == "powerup2")
        {
            powerup2.SetActive(false);
            powerupamount += 1;
        }
        if(toher.tag == "powerup3")
        {
            powerup3.SetActive(false);
            powerupamount += 1;
        }
        if(toher.tag == "speedpowerup")
        {
            speedpowerup.SetActive(false);
            powerupamount += 1;
        }
        if(toher.tag == "powerup4")
        {
            powerup4.SetActive(false);
            powerupamount += 1;
        }
        if(state == "dash")
        {
            if(toher.tag == "shadowenemy")
            {
                Destroy(toher);
                GameConTrolled.instance.addScore(10);
                GameObject healthupobject = Instantiate(healthupsphere, toher.transform.position, Quaternion.identity);
                Destroy(healthupobject, 15);
            }
        }
        else if(toher.tag == "shadowenemy")
        {
            GameConTrolled.instance.health(25);
            Destroy(toher);
        }  
        if(toher.tag == "wisp")
        {GameConTrolled.instance.health(20);
        Destroy(toher);} 
    }
    void inputcheck()
    {
        playerinput = Vector2.ClampMagnitude(new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")),
        1f);
    }
    void blastaround(Vector3 blastdirection)
    {
        Vector3 location = transform.position;
        GameObject blastingaround = Instantiate(blast,location, Quaternion.identity);
        blastbody = blastingaround.GetComponent<Rigidbody2D>();
        blastbody.AddForce(blastdirection.normalized * blastspeed * Time.fixedDeltaTime);
        Destroy(blastingaround, 3);
    }
    void shootarrows(Vector3 voay)
    {       
        Vector3 location = transform.position;
        GameObject shootingarrow = Instantiate(arrow,location,Quaternion.identity);
        arrowbody = shootingarrow.GetComponent<Rigidbody2D>();
        arrowbody.AddForce(voay.normalized * arrowspeed * Time.fixedDeltaTime);
        Destroy(shootingarrow,2);
    }
    void flipanimation()
    {
        var playersprite = GetComponent<SpriteRenderer>();
        if(move_x < -0.002)
        {
            playersprite.flipX = true;
        }
        if(move_x > 0.002)
        {
            playersprite.flipX = false;
        }
    }
    void SetToIdle()
    {
        state = "idle";
        playeranimator.SetTrigger("Startidle");
    }
    void Update()
    {   
        Debug.Log(state);
        staminaslider.value = sprinting;
        dashcooldownslide.value = dashcd;
        blastcooldownslider.value = blastaroundtime;
        dashcd += 1 * Time.deltaTime;
        poweruptext.text = $"Powerups: {powerupamount} / 6";
        if(state == "running")
        {
            if(Input.GetButtonDown("Fire2"))
            {
                if(dashcd > 5)
                {                
                    state = "dash";
                    dashcd = 0;
                    Invoke("SetToIdle", 0.2f);
                }
            }
        }
        if(dashcd < 5)
        {
            
        }
        if(sprinting < 10)
        {
            sprinting += 1 * Time.deltaTime;
        }
        if(Input.GetButton("Fire3"))
        {
            nopeus = 7;
            if(speedpowerup.activeSelf == false)
            {
                nopeus = 8;
            }
            if(sprinting > 0)
            {
                sprinting -= 3 * Time.deltaTime;
            }
            if(sprinting < 0)
            {
                sprinting += 2 * Time.deltaTime;
                nopeus = 5;
                if(speedpowerup.activeSelf == false)
                nopeus = 7;
            }
        }
        else
        {
            nopeus = 5;
            if(speedpowerup.activeSelf == false)
            nopeus = 7;
        }
        flipanimation();
        shootcd -= 1 * Time.fixedDeltaTime;
        blastaroundtime += 1 * Time.deltaTime;
        if(blastaroundtime > 5)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                blastaround(Vector3.left);
                blastaround(Vector3.up);
                blastaround(Vector3.up + Vector3.left);
                blastaround(Vector3.down);
                blastaround(Vector3.down + Vector3.left);
                blastaround(Vector3.down + Vector3.right);
                blastaround(Vector3.up + Vector3.right);
                blastaround(Vector3.right);
                blastaroundtime = 0;
            }
        }
        if(state == "idle")
        {
            inputcheck();
            if(playerinput.magnitude > 0.002)
            {
                playeranimator.SetTrigger("StartRunning");
                state = "running";
            }
        }
        if (state == "running")
        {
            inputcheck();
            if(playerinput.magnitude < 0.002)
            {   
                SetToIdle();
            }
        }
        if(state == "dash")
        {

        }
    }
    void FixedUpdate()
    {
        movement.AddForce(Vector2.zero);
        Vector3 suunta = movement.velocity;
        Vector3 location = transform.position;
        move_x = Input.GetAxisRaw("Horizontal");
        move_y = Input.GetAxisRaw("Vertical");

        if(state == "dash")
        {
            movement.MovePosition(transform.position + new Vector3(move_x, move_y, 0) * Time.fixedDeltaTime * dashnopeus);
        }
        else
        {
            movement.MovePosition(transform.position + new Vector3(move_x, move_y, 0) * Time.fixedDeltaTime * nopeus);
        }
        
        if(shootcd < 0)
        {                        
            shootarrows(Vector3.right);
            shootcd= 2;
            if(powerup.activeSelf == false)
            {
                shootarrows(Vector3.up);
            }
            if(powerup1.activeSelf == false)
            {
                shootarrows(Vector3.down);
            }
            if(powerup2.activeSelf == false)
            {
                shootarrows(Vector3.left);
            }            
            if(powerup3.activeSelf == false)
            {
                shootcd = 1;
            }
            if(speedpowerup.activeSelf == false)
            {
                nopeus = 7;
            }
        }      
    }
}
