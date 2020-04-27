using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{

    public GameObject shellenCountTextObject;
    public GameObject usdCountTextObject;

    // Currency of the game.
    // Name is both a corruption of "shilling" and a reference to the historical
    // use of shells as money.
    public int shellen;

    // The conversion rate of shellen to US Dollars.
    public float conversionRate;

    // The amount of money the player earns on every frame update.
    public int shellenPerFrame;

    // The amount of money the player earns every time they click the big banknote.
    public int shellenPerClick;

    // Start is called before the first frame update
    void Start()
    {
        shellen = 0;
        conversionRate = 2.1f;
        shellenPerFrame = 0;
        shellenPerClick = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the player's money count by the specified value.
        shellen += shellenPerFrame;
        UpdateText();
    }

    public void ClickBanknote()
    {
        shellen += shellenPerClick;
        UpdateText();
    }

    void UpdateText()
    {
        TextMeshProUGUI shellenCount = shellenCountTextObject.GetComponent<TextMeshProUGUI>();
        shellenCount.SetText(string.Format("§ {0}", shellen));

        TextMeshProUGUI usdCount = usdCountTextObject.GetComponent<TextMeshProUGUI>();
        usdCount.SetText(string.Format("$ {0:#.00}", shellen * conversionRate));
    }

}
