using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairingRobot : State
{
    GameStateTracker context;

    public RepairingRobot(GameStateTracker context)
    {
        this.context = context;
    }

    public void ShowInfo()
    {
        context.confirmButton.SetActive(true);

        // reveal success meter
        // reveal part + cards?
        context.currentPart.SetActive(true);
    }

    public void ChangeState()
    {
        // maybe show whether player succeeded or failed then invoke helper method 
        // to execute following code

        context.confirmButton.SetActive(false);
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
