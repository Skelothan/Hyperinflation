using System.Collections;
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
        gameObject.GetComponent<Button>().interactable = moneyCounter.shellen >= buildingCostShellen;

        buttonText.SetText(string.Format("§ {0}\n{1}", buildingCostShellen, buildingName));
    }

    public void BuyThisThing()
    {
        if (moneyCounter.shellen >= buildingCostShellen)
        {
            moneyCounter.shellen -= buildingCostShellen;
            // Only increase the building number if this doesn't buy bread
            if (buildingType != 0)
                shopScript.numBuildings[buildingType]++;
        }
        moneyCounter.UpdateText();
        
        shopScript.OnBuildingPurchase();

    }
}
