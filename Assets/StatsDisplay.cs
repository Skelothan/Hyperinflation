using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{

    public GameObject moneyCountObject;
    public GameObject statsTextObject;

    private MoneyCounter moneyCounter;

    public int banknotesMade;
    public int totalIncome;

    // Start is called before the first frame update
    void Start()
    {
        banknotesMade = 0;
        totalIncome = 0;

        moneyCounter = moneyCountObject.GetComponent<MoneyCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI statsTextMeshPro = statsTextObject.GetComponent<TextMeshProUGUI>();
        statsTextMeshPro.SetText(string.Format("Banknotes made: {0}\nTotal income: § {1}\nShellen to USD: § {2} : $ 1", banknotesMade, totalIncome, moneyCounter.conversionRate));
    }
}
