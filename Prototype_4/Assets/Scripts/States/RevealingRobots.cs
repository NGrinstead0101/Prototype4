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

        context.corpLogoImage.enabled = true;
        context.corpLogoImage.sprite = context.corpLogoSprites[currentRobot.Corp];

        //string corpName = "";
        //switch (currentRobot.Corp)
        //{
        //case 0:
        //corpName = "Pear Corp.";
        //break;

        //case 1:
        //corpName = "Cyborg Inc.";
        //break;

        //case 2:
        //corpName = "MEGAplex";
        //break;
        //}

        context.speechBubble.SetActive(true);
        context.dialogueBox.text = currentRobot.Dialogue;

        //get part refference
        context.currentPart = currentRobot.Part;
        context.currentPart.GetComponent<Part>().UpdateSuit(currentRobot.Corp);

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
