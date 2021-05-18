using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //this script will start and stop auto walking when 
    //player looks directly a the cube

    public static Action OnCubeHit;
    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Disk")
        {
                hit = true;
        }
        
    }
    public bool getHit()
    {
        return hit;
    }
}
