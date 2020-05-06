using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public static GameState instance;

    private string state;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        state = "night";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(string newState)
    {
        state = newState;
    }

    public string GetState()
    {
        return state;
    }

    public void StartDay()
    {
        Timer.instance.ResetTimer();
        ChangeState("day");
    }
}
