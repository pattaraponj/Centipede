using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSipder : MonoBehaviour
{// Start is called before the first frame update
    public float spawnTime;
   
    public GameObject spider;
   
    void Start()
    {
        spawnTime=10;

        InvokeRepeating("AddSpider", spawnTime, 10);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void AddSpider()
    {
        

        // Instantiate the food at (x, y)
        Instantiate(spider,
                    new Vector2(0, 0),
                    Quaternion.identity); // default rotation
    }
}
