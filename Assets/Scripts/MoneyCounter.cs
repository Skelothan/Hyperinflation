using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{

    public GameObject shellenCountTextObject;
    public GameObject usdCountTextObject;
    public GameObject statsDisplayObject;

    private StatsDisplay statsDisplay;

    // Currency of the game.
    // Name is both a corruption of "shilling" and a reference to the historical
    // use of shells as money.
    public int shellen;

    // The conversion rate of shellen to US Dollars.
    public float conversionRate;

    // The amount of money the player earns on every frame update.
    public int shellenPerSecond;

    // The amount of money the player earns every time they click the big banknote.
    public int shellenPerClick;

    public float inflationRate;

    private int timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        // Run the game at 60 fps
        Application.targetFrameRate = 60;

        shellen = 0;
        conversionRate = 2f;
        shellenPerSecond = 0;
        shellenPerClick = 1;
        timeElapsed = 0;

        statsDisplay = statsDisplayObject.GetComponent<StatsDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the player's money count by the specified value.
        timeElapsed++;
        if (timeElapsed % 60 == 0)
        {
            shellen += shellenPerSecond;
            statsDisplay.incrementBanknotesCount();
            statsDisplay.totalIncome += shellenPerSecond;
            conversionRate = Mathf.Pow(inflationRate, timeElapsed) + 1;
            UpdateText();
        }

    }

    public void ClickBanknote()
    {
        shellen += shellenPerClick;
        statsDisplay.banknotesMade++;
        statsDisplay.totalIncome += shellenPerClick;
        UpdateText();
    }

    public void UpdateText()
    {
        TextMeshProUGUI shellenCount = shellenCountTextObject.GetComponent<TextMeshProUGUI>();
        shellenCount.SetText(string.Format("§ {0}", shellen));

        TextMeshProUGUI usdCount = usdCountTextObject.GetComponent<TextMeshProUGUI>();
        usdCount.SetText(string.Format("$ {0:0.00}", shellen / conversionRate));
    }

}
