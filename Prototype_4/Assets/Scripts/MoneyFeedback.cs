using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class MoneyFeedback : MonoBehaviour
{
    Part currentPart;
    [SerializeField] TextMeshProUGUI moneyFeedbackText;
    bool isProvidingFeedback = false;
    [SerializeField] GameObject background;

    // called by a State class to add the current part
    public void AddPart(Part newPart)
    {
        currentPart = newPart;
        isProvidingFeedback = true;
        background.SetActive(true);
    }

    // called by a State class to clear sleeveList between robots
    public void ResetFeedback()
    {
        currentPart = null;
        moneyFeedbackText.text = "";
        isProvidingFeedback = false;
        background.SetActive(false);
    }

    private void Update()
    {
        if (isProvidingFeedback)
        {
            string newFeedback = "";

            int numIsEmpty = currentPart.checkIsEmpty();
            if (numIsEmpty != 0)
            {
                newFeedback += "-$" + (40 * numIsEmpty) + " unfilled slots";
            }

            int numTypeMatches = currentPart.checkType();
            if (numTypeMatches != 0)
            {
                newFeedback += "\n+$" + (20 * numTypeMatches) + " matching types";
            }

            int numCorpMatches = currentPart.checkCorp();
            int successAmount = Mathf.CeilToInt(currentPart.sleeves / 2f);
            if (numCorpMatches >= successAmount)
            {
                newFeedback += "\n+$" + (30 * numCorpMatches) + " matching corporations";
            }
            else
            {
                newFeedback += "\n+$0 not enough corporation matches";
            }

            moneyFeedbackText.text = newFeedback;
        }
    }
}
