using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    Rigidbody2D r2d;
    public float posY;
    int swictherY;
    public GameObject joint;
    
    Animator aniCentipede;
    Vector3 scale;
   
    SpriteRenderer spR;
    
    bool facingRight;


    void Start()
    {
        posY = 0.0f;
        speed = -1;
        swictherY = 1;
        // Get component
        r2d = GetComponent<Rigidbody2D>();
        spR = GetComponent<SpriteRenderer>();
        aniCentipede = GetComponent<Animator>();
       
       

        r2d.velocity= new Vector2(speed,0.0f);
        
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (joint.gameObject != null)
        {

            // aniCentipede.SetBool("IsHead", true);
            if (Vector2.Distance(transform.position, joint.gameObject.transform.position) > 0.28f)
            {
                transform.position = Vector2.MoveTowards(transform.position, joint.gameObject.transform.position, Time.deltaTime * 3);                
                
            }

        }
        if (joint.gameObject == null)
        {
            ///  aniCentipede.SetBool("IsHead", true);
            aniCentipede.Play("CenHead");
            r2d.velocity = new Vector2(speed, posY);
          
        }
        
        

    }
      


    // Function called when the object goes out of the screen
    void OnBecameInvisible()
    {
        
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Mushroom")
        {
            if (joint.gameObject == null)
            {
                Flip();
                speed *= -1;
                
                r2d.position -= new Vector2(0, 0.3f * swictherY);
                facingRight = true;

                print("I Hit wall Col" );
            }
        }
        if (collision.gameObject.tag == "WallTopBut")
        {
            if (joint.gameObject == null)
            {
                swictherY *= -1;
                print("I Hit wall2 Col" + swictherY);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D  obj)
    {
        // Name of the object that collided with the enemy
        

        if (obj.gameObject.tag == "Wall" || obj.gameObject.tag == "Mushroom"||transform.position.x<-5)
        {
            print("I am " + transform.position.x);
            if (joint.gameObject == null)
            {
                speed *= -1;
               
                r2d.position -= new Vector2(0, 0.3f * swictherY);
               //ransform.rotation.z = 180;
               //cale.x *= -1;
                print("I Hit wall2" + transform.position.x );
            }
        }
        if (obj.gameObject.tag == "WallTopBut")
        {
            if (joint.gameObject == null)
            {
                swictherY *= -1;
                print("I Hit wall2" + swictherY);
            }
        }
       
        // If the enemy collided with a bullet
        if (obj.gameObject.tag == "Bullet")
        {
            GameInfo.score += 200;
            // Destroy itself (the enemy) and the bullet
            if (joint.gameObject == null)
            {
                speed *= -2;

                r2d.position -= new Vector2(0, 0.3f * swictherY);
                
            }
            Destroy(gameObject);
            Destroy(obj.gameObject);
        }
      

        // If the enemy collided with the spaceship
        if (obj.gameObject.tag == "Player")
        {
            // Destroy itself (the enemy) to keep things simple
            Destroy(gameObject);
            GameInfo.life--;
        }
    }


    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
