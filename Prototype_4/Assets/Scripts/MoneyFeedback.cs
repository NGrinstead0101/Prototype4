using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyFeedback : MonoBehaviour
{
    List<Sleeve> sleeveList = new List<Sleeve>();
    [SerializeField] TextMeshProUGUI moneyFeedbackText;
    bool isProvidingFeedback = false;

    // called by sleeves to add themselves to the list when enabled
    public void AddSleeveToList(Sleeve newSleeve)
    {
        sleeveList.Add(newSleeve);
        isProvidingFeedback = true;
    }

    // called by a State class to clear sleeveList between robots
    public void ResetFeedback()
    {
        sleeveList.Clear();
        moneyFeedbackText.text = "";
        isProvidingFeedback = false;
    }

    private void Update()
    {
        if (isProvidingFeedback)
        {

        }
    }
}
