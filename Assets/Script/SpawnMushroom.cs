using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMushroom : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnTime;
    public int startMushroon;
    // Variable to store the enemy prefab
    public GameObject mushroom;
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Start()
    {
        spawnTime = 10;
        // Call the 'addEnemy' function in 0 second
        // Then every 'spawnTime' seconds
        for (int i = 0; i < startMushroon; i++) {
            Invoke("AddMushroom",0.2f);
    }

        InvokeRepeating("AddMushroom", spawnTime, Random.Range(1, 5));
    }

    // Update is called once per frame
    void Update()
    {

       
      
    }

  


    // New function to spawn an enemy
    void AddMushroom()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

        // Instantiate the food at (x, y)
        Instantiate(mushroom,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}
