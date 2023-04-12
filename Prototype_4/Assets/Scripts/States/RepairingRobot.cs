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

        //context.currentPart.GetComponent<Part>().check();

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


