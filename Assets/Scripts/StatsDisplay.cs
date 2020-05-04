using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{

    public GameObject moneyCountObject;
    public GameObject statsTextObject;
    public GameObject shopObject;

    private MoneyCounter moneyCounter;
    private BuildingItems shopScript;

    public int banknotesMade;
    public int totalIncome;

    // Start is called before the first frame update
    void Start()
    {
        banknotesMade = 0;
        totalIncome = 0;

        moneyCounter = moneyCountObject.GetComponent<MoneyCounter>();
        shopScript = shopObject.GetComponent<BuildingItems>();

        Update();
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI statsTextMeshPro = statsTextObject.GetComponent<TextMeshProUGUI>();
        statsTextMeshPro.SetText(string.Format("" +
            "Banknotes made: {0}\nTotal income: § {1}\nIncome per second: § {2}/s\nShellen to USD: § {3:0.00} : $ 1\nPrinters owned: {4}\n\n" +
            "Bread: {5}", 
            banknotesMade, totalIncome, moneyCounter.shellenPerSecond, moneyCounter.conversionRate, shopScript.totalBuildings, 
            shopScript.GetBreadCount()));
    }

    public void incrementBanknotesCount()
    {
        banknotesMade += shopScript.totalBuildings;
    }

}
