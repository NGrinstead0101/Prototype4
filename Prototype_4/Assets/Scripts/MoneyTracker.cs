using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTracker : MonoBehaviour
{
    public int moneyTotal = 0;

    [SerializeField] TextMeshProUGUI moneyText;

    public void GainMoney(int money)
    {
        moneyTotal += money;
        moneyText.text = "$" + moneyTotal;
    }

    public void SpendMoney(int money)
    {
        moneyTotal -= money;
        moneyText.text = "$" + moneyTotal;
    }
}
