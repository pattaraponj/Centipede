using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    public Sprite alive4, alive3, alive2, alive1;
    int aliveStatus;
    SpriteRenderer spFrame;
    int mushroomScore;
    
    // Start is called before the first frame update
    void Start()
    {
        aliveStatus = 4;
        
        spFrame =GetComponent<SpriteRenderer>();
        mushroomScore = 10;



    }

    // Update is called once per frame
   void FixedUpdate()
    {
        print("mushroomlife" + aliveStatus);
        switch (aliveStatus)
        {
            case 1:
                
                spFrame.sprite = alive1;
                break;
            case 2:
                spFrame.sprite = alive2;
                break;
            case 3:
                spFrame.sprite = alive3;
                break;
            default:
                spFrame.sprite = alive4;
                break;
        }

    }
   

    void OnTriggerEnter2D(Collider2D obj)
    {

        if (obj.gameObject.tag == "Bullet")
        {
            // Destroy itself (the enemy) and the bullet
            aliveStatus--;
            GameInfo.score += mushroomScore; 
            Destroy(obj.gameObject);

            if (aliveStatus < 1)
            {
            Destroy(gameObject);

                aliveStatus--;
                

            }

            if (obj.gameObject.tag == "Wall" || obj.gameObject.tag == "Mushroom")
            {
                Destroy(gameObject);
                print("Destroy2 Obj" + obj.gameObject.name);
            }

        }


       
    }
     void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Mushroom")
        {
            Destroy(gameObject);
            print("Destroy2 Obj" + collision.gameObject.name);
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Mushroom")
        {
            Destroy(gameObject);
            print("Destroy Obj" + collision.gameObject.name);
        }
    }
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }


}
