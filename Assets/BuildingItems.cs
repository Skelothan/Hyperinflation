using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingItems : MonoBehaviour
{

    public GameObject moneyCountObject;
    private MoneyCounter moneyCounter;

    public int[] numBuildings;
    public int[] shellenProductions;

    public int totalBuildings;

    // Start is called before the first frame update
    void Start()
    {
        moneyCounter = moneyCountObject.GetComponent<MoneyCounter>();
        shellenProductions = new int[] { 0, 1, 5 };
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
}
