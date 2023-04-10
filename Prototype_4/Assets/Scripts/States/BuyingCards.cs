using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingCards : State
{
    GameStateTracker context;

    public BuyingCards(GameStateTracker context)
    {
        this.context = context;
    }

    public void ShowInfo()
    {
        context.confirmButton.SetActive(true);

        context.storeInterface.SetActive(true);

        context.robotGenerator.GenerateRobots();

        // show PA message if needed
    }

    public void ChangeState()
    {
        context.confirmButton.SetActive(false);

        context.storeInterface.SetActive(false);

        context.currentState = GameStateTracker.revealingRobots;

        Debug.Log("State changed to revealing robots");

        context.ShowInfo();
    }
}
