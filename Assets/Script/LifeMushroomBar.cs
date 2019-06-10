using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeMushroomBar : MonoBehaviour
{
    Text tx;
    void Start()
    {
        tx = GetComponent<Text>();

       


    }

    // Update is called once per frame
    void Update()
    {
        tx.text = "Score" + GameInfo.score;    
                      
    }
}
