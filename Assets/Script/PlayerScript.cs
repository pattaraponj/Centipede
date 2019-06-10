using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the rigidbody componentz
        if (GameInfo.life > 0)
        {
            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

            // Move the spaceship when an arrow key is pressed
            if (Input.GetKey("right"))
            {
                rb2d.velocity = new Vector2(2.0f, 0);
            }
            else if (Input.GetKey("left"))
            {
                rb2d.velocity = new Vector2(-2.0f, 0);
            }
            else if (Input.GetKey("up")&&rb2d.transform.position.y<-3.5f)
            {
                rb2d.velocity = new Vector2(0, 2.0f);
                print("Up");
            }
            else if (Input.GetKey("down"))
            {
                rb2d.velocity = new Vector2(0, -2.0f);
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
            }
            // When the spacebar is pressed
            if (Input.GetKeyDown("space"))
            {
                // Create a new bullet at “transform.position” 
                // Which is the current position of the ship
                // Quaternion.identity = add the bullet with no rotation
                Instantiate(bullet, transform.position, Quaternion.identity);
                print("Shoot one");
            }
        }
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");


    }
}
 


    

