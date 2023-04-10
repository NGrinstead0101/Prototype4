using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealingRobots : State
{
    GameStateTracker context;

    public RevealingRobots(GameStateTracker context)
    {
        this.context = context;
    }

    public void ShowInfo()
    {
        Robot currentRobot = context.robotQueue.Dequeue();

        context.dialogueBox.text = currentRobot.Dialogue;

        // reveal part

        // update robot sprite
        context.robotSprite.enabled = true;
        context.robotSprite.sprite = currentRobot.RobotSprite;

        context.Invoke("GetContinueInput", 2f);
    }

    public void ChangeState()
    {
        context.currentState = GameStateTracker.repairingRobot;

        Debug.Log("State changed to repairing");

        context.ShowInfo();
    }
}
