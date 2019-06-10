using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCentipede : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnTime;
    public int longCen;
    float PosX;
   
    // Variable to store the enemy prefab
    public GameObject enemyHead;
    public GameObject enemyBody;
    void Start()
    {
    spawnTime = 2;
        // Call the 'addEnemy' function in 0 second
        // Then every 'spawnTime' seconds

        // InvokeRepeating("AddEnemy", 0, spawnTime);
        float PosX=4.8f;
        Invoke("AddEnemy", 0);
        
        
        
        
        
}

    // Update is called once per frame
    void Update()
    {



    }

    // New function to spawn an enemy
    void AddEnemy()
    {
       
        // Get the renderer component of the spawn object
        Renderer rd = GetComponent<Renderer>();



        // Randomly pick a point within the spawn object
        Vector2 spawnPoint = new Vector2(PosX, 4.8f);
        Instantiate(enemyHead, spawnPoint, Quaternion.identity);
        // Create an enemy at the 'spawnPoint' position
        for (int i = 0; i < longCen; i++)
        {

            float positionX = spawnPoint.x + (0.28f * i);


            Vector2 spawnPointFollow = new Vector2(positionX, 4.8f);

            Instantiate(enemyBody, spawnPointFollow, Quaternion.identity);
        }
        
    }

   
        

   
}
