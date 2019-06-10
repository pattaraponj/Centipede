using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    Rigidbody2D r2d;
  float posY;
    public float spawnTime;
    int swictherY;
    Vector2 targetPlayer;
    public GameObject player;
    bool actract;
    float timeLeft;
    void Start()
    {
        posY = -0.5f;
        speed = -0.5f;
        swictherY = 1;
        timeLeft = 10;
        // Get the rigidbody component
        r2d = GetComponent<Rigidbody2D>();

        // Add a vertical speed to the enemy
        r2d.velocity = new Vector2(0, 0);
        spawnTime = 10;

        InvokeRepeating("AddSpider", spawnTime, 10);


        actract = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeLeft > 0&& actract)
        {timeLeft -= Time.deltaTime;
            targetPlayer = player.gameObject.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer, Time.deltaTime * 2);
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                actract = !actract;
            }
        }
        //  speed = Random.Range(-2, 2);
        //  posY= Random.Range(-2, 2);
        r2d.velocity = new Vector2(speed, posY);
        if (r2d.position.x<-5)
        {
            speed = 0.5f;
            if(r2d.position.y < -4.5f)
            {

                posY = 0.5f;
            }
            else if (r2d.position.y > 0)
            {

                posY = -0.5f;
            }
        }
        else if (r2d.position.x > 5)
        {
            speed = -0.5f;
            if (r2d.position.y < -4.5f)
            {

                posY = 0.5f;
            }
            else if (r2d.position.y > 0)
            {

                posY = -0.5f;
            }
        }
        

    }
   


    // Function called when the object goes out of the screen
    void OnBecameInvisible()
    {
        // Destroy the enemy
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Mushroom")
        {
            speed *= -1;
            //posY *= -1;
            timeLeft=10;
            r2d.position -= new Vector2(0, 0.3f * swictherY);
            actract = true;
            print("Spider Hit wall2" + swictherY);

        }
        if (collision.gameObject.tag == "WallTopBut")
        {
            swictherY *= -1;
            print("Spider Hit wall2" + swictherY);

        }
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
       

        if (obj.gameObject.tag == "Wall" || obj.gameObject.tag == "Mushroom")
        {
           // speed *= -1;
           // posY *= -1;
          //  r2d.position -= new Vector2(0, 0.3f * swictherY);
            actract = true;
            print("Spider Hit wall2" + swictherY);

        }
        if (obj.gameObject.tag == "WallTopBut")
        {
           // swictherY *= -1;
            print("Spider Hit wall2" + swictherY);

        }
       

        // If the enemy collided with a bullet
        if (obj.gameObject.tag == "Bullet")
        {
            // Destroy itself (the enemy) and the bullet
            GameInfo.score = +600;
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

    void AddSpider()
    {


        // Instantiate the food at (x, y)
        Instantiate(gameObject,
                    new Vector2(0, 0),
                    Quaternion.identity); // default rotation
    }
}
