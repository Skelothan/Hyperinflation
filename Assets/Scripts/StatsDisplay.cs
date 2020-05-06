using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    public GameObject statsTextObject;
    public GameObject shopObject;

    private MoneyCounter moneyCounter;
    private BuildingItems shopScript;
    private Timer timerScript;

    public int banknotesMade;
    public int totalIncome;

    // Start is called before the first frame update
    void Start()
    {
        banknotesMade = 0;
        totalIncome = 0;

        moneyCounter = MoneyCounter.instance;
        shopScript = BuildingItems.instance;
        timerScript = Timer.instance;

        Update();
    }

    // Update is called once per frame
    void Update()
    {
        string breadString = "no";
        if (shopScript.GetBreadCount() == 1)
            breadString = "yes";


        TextMeshProUGUI statsTextMeshPro = statsTextObject.GetComponent<TextMeshProUGUI>();
        statsTextMeshPro.SetText(string.Format("" +
            "Banknotes made: {0}\nTotal income: § {1}\nIncome per second: § {2}/s\nShellen to USD: § {3:0.00} : $ 1\nPrinters owned: {4}\n\n" +
            "Date: {5}\nPurchased Bread Today? : {6} ", 
            banknotesMade, totalIncome, moneyCounter.shellenPerSecond, moneyCounter.conversionRate, shopScript.totalBuildings,
            timerScript.GetDate(), breadString));
    }

    public void incrementBanknotesCount()
    {
        banknotesMade += shopScript.totalBuildings;
    }

}
