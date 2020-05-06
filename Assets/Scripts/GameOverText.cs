using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = 0f;
        if (GameState.instance.GetState() == "gameover")
            alpha = 1f;
            
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);
    }
}
