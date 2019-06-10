using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level1");
              GameInfo.itemCount = 0;            
            GameInfo.life = 3;
        
            GameInfo.score = 0;
}
    }
}