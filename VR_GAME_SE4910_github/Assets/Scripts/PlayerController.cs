﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static Action OnPlayerDied = null;
    
    public GameObject diskPrefab;
    public Transform diskTransform;
    public float speed = 70;

    void Start(){
        
    }

    void Update(){
          if (Input.GetKeyDown(KeyCode.Mouse0))
           {
                Debug.Log("shoot one disk");
                GameObject tempBall = Instantiate(diskPrefab, diskTransform.position, diskTransform.rotation);
            
                //need to add velocity to the ball
                tempBall.GetComponent<Rigidbody>().velocity = diskTransform.forward*speed;
           
           }

    }
    void OnTriggerEnter(Collider other)
    {
        //if we get caught
        if (other.gameObject.tag == "bird")
        {
            //checking if someone subscribes to the listener
            if (OnPlayerDied != null)
            {
                //trigger game over functionality
                OnPlayerDied();
            }
            Debug.Log("player dies");


        }

    }


}
