using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    HandTracker handTracker;
    MoneyTracker moneyTracker;
    Button buttonComponent;

    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] int price;

    [SerializeField] int corp;
    [SerializeField] int type;

    private void Awake()
    {
        handTracker = GameObject.FindGameObjectWithTag("HandTracker").GetComponent<HandTracker>();
        moneyTracker = GameObject.FindGameObjectWithTag("MoneyTracker").GetComponent<MoneyTracker>();
        buttonComponent = GetComponent<Button>();

        priceText.text = "$" + price;
    } 

    private void Update()
    {
        if (moneyTracker.moneyTotal < price)
        {
            buttonComponent.interactable = false;
        }
        else
        {
            buttonComponent.interactable = true;
        }
    }

    public void SendCardParameters()
    {
        moneyTracker.SpendMoney(price);
        handTracker.BuyCard(corp, type);
    }
}
