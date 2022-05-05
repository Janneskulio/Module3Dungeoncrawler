using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameConTrolled : MonoBehaviour
{
    public static GameConTrolled instance;
    [SerializeField] GameObject enemy, enemysecond, spirit, shadowenemy, bossenemy;
    [SerializeField] Rigidbody2D enemybody;
    [SerializeField] float instcd = 0.0f;
    [SerializeField] int enemore = 0, enesecond = 0, enespirit = 0,eneshadow = 0, eneboss = 0;
    [SerializeField] Text scoretext;
    [SerializeField] int score = 0, waveamount = 0;
    public int playerhp = 300;
    [SerializeField] Text playerhptext, wavetext, gameover;
    [SerializeField] Slider Wave, playerhpslider;
    [SerializeField] GameObject restart;
    void Start()
    {
        instance = this;
        gameover.enabled = false;
        restart.SetActive(false);
        Time.timeScale = 1;
    }
    void BossSpawner()
    {
        var spot = new Vector3(0,20, 0);
        GameObject BossInst = Instantiate(bossenemy, spot, Quaternion.identity);
    }
    void enemyspawner()
    {
        var alue = new Vector3(Random.Range(35,-35),Random.Range(20, -15),0);
        GameObject EnemySpawner = Instantiate(enemy,alue,Quaternion.identity);

    }
    void enemysecondspawner()
    {
        var alue = new Vector3(Random.Range(35,-35),Random.Range(20, -15),0);
        GameObject enemysecondspawn = Instantiate(enemysecond,alue,Quaternion.identity);

    }
    void spiritspawner()
    {
        var alue = new Vector3(Random.Range(35,-35),Random.Range(20, -15),0);
        GameObject spiritspawn = Instantiate(spirit,alue,Quaternion.identity);
    }
    void shadowenemyspawner()
    {
        var alue = new Vector3(Random.Range(35,-35),Random.Range(20, -15),0);
        GameObject shadowspawn = Instantiate(shadowenemy,alue,Quaternion.identity);
    }
    void Update()
    {
        playerhpslider.value = playerhp;
        Wave.value = instcd;
        instcd += 1 * Time.deltaTime;
        if(waveamount == 20 || waveamount == 25)
        {
            Wave.maxValue = 40;    
            if(instcd >40)
            {AddEnemy();}
        }
        else 
        {   
            if (instcd > 15)
            {
            Wave.maxValue = 15;
            AddEnemy();
            }
        }
        if(playerhp < 10)
        {
            var terve  = restart.GetComponent<Button>();
            restart.SetActive(true);
            gameover.enabled = true; 
            Time.timeScale = 0;
        }
    }
    public void addScore(int AddToScore)
    {
        score += AddToScore;
        scoretext.text = $"Score: {score}";
    }
    public void health(int minushealth)
    {
        playerhp -= minushealth;
        playerhptext.text = $"{playerhp}";
    }
    void AddEnemy()
    {
        waveamount += 1;
        if(waveamount == 20 || waveamount == 25)
        {
            for (int i = 0; i < eneboss; i++)
            {
                BossSpawner();
            }
            eneboss++;
        }
        else
        {
            for (int i = 0; i < enemore; i++)
            {enemyspawner();}
            
            for (int i = 0; i < enesecond; i++)
            {enemysecondspawner();}
            
            for (int i = 0; i < enespirit; i++)
            {spiritspawner();}
            
            for (int i = 0; i < eneshadow; i++)
            {shadowenemyspawner();}   
        }
       
        wavetext.text = $"Wave: {waveamount}";
        enesecond++;
        if(waveamount > 3)
        {enemore++;}
        if(waveamount > 8)
        {enespirit++;}
        if(waveamount > 13)
        {eneshadow++;}
        instcd = 0;
        
    }
}
