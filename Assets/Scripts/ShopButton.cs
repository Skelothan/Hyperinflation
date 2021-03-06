﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{

    public GameObject shopObject;
    private BuildingItems shopScript;

    public GameObject buttonTextObject;
    private TextMeshProUGUI buttonText;

    public string buildingName;

    public GameObject moneyCountObject;
    private MoneyCounter moneyCounter;

    // The ID of the building type
    public int buildingType;
    public int buildingCostUSD;
    private int buildingCostShellen;

    // Start is called before the first frame update
    void Start()
    {
        shopScript = shopObject.GetComponent<BuildingItems>();
        moneyCounter = moneyCountObject.GetComponent<MoneyCounter>();
        buttonText = buttonTextObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        buildingCostShellen = (int)Mathf.Round(buildingCostUSD * moneyCounter.conversionRate);
        if (buildingType == 0)
            gameObject.GetComponent<Button>().interactable = moneyCounter.shellen >= buildingCostShellen && shopScript.numBuildings[buildingType] < 1 && GameState.instance.GetState() == "day";
        else
            gameObject.GetComponent<Button>().interactable = moneyCounter.shellen >= buildingCostShellen && GameState.instance.GetState() == "day";

        buttonText.SetText(string.Format("§ {0}\n{1}", buildingCostShellen, buildingName));
    }

    public void BuyThisThing()
    {
        if (moneyCounter.shellen >= buildingCostShellen)
        {
            moneyCounter.shellen -= buildingCostShellen;
            shopScript.numBuildings[buildingType]++;
        }
        moneyCounter.UpdateText();

        // Only increase the total buildings number / update the shellen per second count if this doesn't buy bread
        if (buildingType != 0)
            shopScript.OnBuildingPurchase();
        else
            buildingCostUSD += 12;

    }
}
