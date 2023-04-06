using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateTracker : MonoBehaviour
{
    Queue<Robot> robotQueue = new Queue<Robot>();
    [SerializeField] RobotGenerator robotGenerator;

    enum GameState { revealRobot, waitingOnRepairs, checkRepairs, buyingCards, waitingOnBuying };
    GameState currentGameState;

    [SerializeField] TextMeshProUGUI dialogueBox;

    [SerializeField] GameObject storeInterface;
    // variable referencing PA message (probably other class?)

    /// <summary>
    /// Creates robots for first day
    /// </summary>
    private void Awake()
    {
        robotGenerator.GenerateRobots();
        currentGameState = GameState.revealRobot;
    }

    /// <summary>
    /// Handles switching between game states
    /// </summary>
    private void Update()
    {
        switch (currentGameState)
        {
            case GameState.revealRobot:
                Debug.Log("Revealing robots");
                currentGameState = GameState.waitingOnRepairs;
                //HideStore();
                ShowNextRobot();
                break;

            case GameState.checkRepairs:
                Debug.Log("Checking repairs");
                // check for success and reveal results
                // change state to reveal if robots remain, otherwise go to buying
                if (robotQueue.Count > 0)
                {
                    currentGameState = GameState.revealRobot;
                }
                else
                {
                    currentGameState = GameState.buyingCards;
                }
                break;

            case GameState.buyingCards:
                Debug.Log("Moving to buying phase");
                currentGameState = GameState.waitingOnBuying;
                robotGenerator.GenerateRobots();
                // show PA message
                //ShowStore();
                break;

            default:
                Debug.Log("Waiting...");
                break;
        }
    }

    /// <summary>
    /// Called by RobotGenerator to add new robots to queue
    /// </summary>
    /// <param name="robotList"></param>
    public void AddRobots(List<Robot> robotList)
    {
        robotQueue.Clear();

        foreach (Robot robot in robotList)
        {
            Debug.Log("Corp: " + robot.Corp + "  Has Security: " + robot.HasSecurity + "  Dialogue: " + robot.Dialogue);
            robotQueue.Enqueue(robot);
        }
    }

    /// <summary>
    /// Called to reveal the next robot
    /// </summary>
    private void ShowNextRobot()
    {
        Robot currentRobot = robotQueue.Dequeue();

        dialogueBox.text = currentRobot.Dialogue;

        // reveal part
    }

    private void ShowStore()
    {
        storeInterface.SetActive(true);
    }

    private void HideStore()
    {
        storeInterface.SetActive(false);
    }

    public void StopWaiting()
    {
        // moves to next phase based on which type of waiting is happening
        if (currentGameState == GameState.waitingOnRepairs)  
        {
            currentGameState = GameState.checkRepairs;
        }
        else if (currentGameState == GameState.waitingOnBuying)
        {
            currentGameState = GameState.revealRobot;
        }
    }
}
