using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingItems : MonoBehaviour
{

    public static BuildingItems instance;

    private MoneyCounter moneyCounter;

    public int[] numBuildings;
    public int[] shellenProductions;

    public int totalBuildings;

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
        moneyCounter = MoneyCounter.instance;
        shellenProductions = new int[] { 0, 1, 5, 10};
        numBuildings = new int[shellenProductions.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBuildingPurchase()
    {
        moneyCounter.shellenPerSecond = 0;
        //@requires numBuildings.Length == shellenProductions.Length
        for (int i = 0; i < numBuildings.Length; i++)
        {
            moneyCounter.shellenPerSecond += numBuildings[i] * shellenProductions[i];
        }
        totalBuildings++;


    }

    public int GetBreadCount()
    {
        return numBuildings[0];
    }

    public void ConsumeBread()
    {
        if (numBuildings[0] == 0)
            GameState.instance.ChangeState("gameover");
        else
            numBuildings[0]--;
    }
}
