using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = 0f;
        if (GameState.instance.GetState() == "night")
            alpha = 1f;

        gameObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);

        CanvasRenderer[] renderers = gameObject.GetComponentsInChildren<CanvasRenderer>();
        for(int i = 0; i < renderers.Length; i++)
        {
            renderers[i].SetAlpha(alpha);
        }
        gameObject.GetComponent<Button>().interactable = GameState.instance.GetState() == "night";
    }
}
