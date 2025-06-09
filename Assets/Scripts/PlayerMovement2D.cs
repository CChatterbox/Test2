using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 movement;
    public Rigidbody2D rb;
    public int damageScale;
    public GameObject firePoint;
    public GameObject bullet;
    public float bulletSpeed = 10f; 
    
    public Joystick joystick;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {  
       movement.x = joystick.Horizontal;
       movement.y = joystick.Vertical;
       
       movement.Normalize();
       if(movement.x < 0)
       transform.localScale = new Vector3(-5, 5, 5);
        
       if(movement.x > 0)
       transform.localScale = new Vector3(5, 5, 5);
      

        

    }
    void FixedUpdate()
    {
rb.velocity = movement * speed;
    }


    public void Shot()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.Euler(0, 0, 90));
         float direction = 1f; 
        if (transform.localScale.x < 0)
        {
            direction = -1f; 
        }
       

        Rigidbody2D rbBullet = newBullet.GetComponent<Rigidbody2D>(); 
        rbBullet.velocity = new Vector2(direction * bulletSpeed, 0f); 

    }

    
    
}

