using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairingRobot : MonoBehaviour, State
{
    GameStateTracker context;

    public RepairingRobot(GameStateTracker context)
    {
        this.context = context;
    }

    public void ShowInfo()
    {
        context.confirmButton.SetActive(true);

        context.currentPart.SetActive(true);
    }

    public void ChangeState()
    {
        context.confirmButton.SetActive(false);

        //check matches and sleeves
        int corpMatches = context.currentPart.GetComponent<Part>().checkCorp();
        int typeMatches = context.currentPart.GetComponent<Part>().checkType();
        int sleeves = context.currentPart.GetComponent<Part>().returnSleeves();
        //set success value
        int success = Mathf.CeilToInt(sleeves / 2);
        //check for success
        if (corpMatches >= success)
        {
            //add to money tracker
            context.mt.GainMoney(corpMatches * 10);
        }
        if (typeMatches >= success)
        {
            //add to money tracker
            context.mt.GainMoney(typeMatches * 10);
        }


        Invoke("DelayedChange", 2f);
    }

    private void DelayedChange()
    {
        context.dialogueBox.text = "";
        context.robotSprite.enabled = false;
        GameObject.Destroy(context.currentPart);

        if (context.robotQueue.Count > 0)
        {
            context.currentState = GameStateTracker.revealingRobots;
            Debug.Log("State changed to revealing robots");
        }
        else
        {
            context.currentState = GameStateTracker.buyingCards;
            Debug.Log("State changed to buying cards");
        }

        context.ShowInfo();
    }
}


