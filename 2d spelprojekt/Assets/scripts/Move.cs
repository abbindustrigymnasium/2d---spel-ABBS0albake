using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
  
    public float moveSpeed = 2f; //sätter starthastighet

    public Rigidbody2D rb;
   
    Vector2 movement;//variabelm med styr inputs från tangentbord och annat supportat, har två "delar" i variabeln

    void Start()
    {
         //moveSpeed = 1;

    }
    // Update is called once per frame
    void Update()
    {
     
        movement.x = Input.GetAxisRaw("Horizontal");//tar 
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()//oberoende av framerate så säkerställer jämn rörelse när framerate varierar
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);//kör bilen i hastigheten nuvarande plats*styrinput*hastigheten jag satt*tiden
    }
 

    void OnTriggerEnter2D(Collider2D other)//aktiveras när jag kör igenom objekt med respektive tag
    {
        if(other.tag == "SpeedBoost")//röda prickar
        moveSpeed+=3;

        if(other.tag == "SlowDown")//gröna prickar
            if(moveSpeed>3)//hindrar att hastigheten blir för låg, annar skulle hastigheten bli 0 eller negativ vilket är knas
             moveSpeed-=2;

        if(other.tag == "SpeedReset")//väggarna
        moveSpeed = 2;

        if(other.tag == "Start")//startlinjen
        moveSpeed = 5;

       
    }
    
}
