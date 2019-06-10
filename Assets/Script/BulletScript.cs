using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Public variable 
    public int speed;

// Function called once when the bullet is created
 void Start()
    {

        speed = 6;

        // Get the rigidbody component
        Rigidbody2D r2d = GetComponent<Rigidbody2D>();

        // Make the bullet move upward
        r2d.velocity = new Vector2(0,speed);
    }

    // Function called when the object goes out of the screen
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }
}
