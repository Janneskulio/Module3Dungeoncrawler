using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ScanninConTrolled : MonoBehaviour
{
    private float timer =0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.4f)
        {
            timer = 0;
            AstarPath.active.Scan();
        }
    }
}
