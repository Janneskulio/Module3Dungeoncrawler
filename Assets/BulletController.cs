using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int speedofstar = 10;
    void Start()
    {
        
    }

    void Update()
    {
       var liukasluikku = gameObject.GetComponent<Rigidbody2D>();
       liukasluikku.transform.Rotate(new Vector3(0.0f,0.0f,-90.0f) * speedofstar * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
    }
}
