using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTracker : MonoBehaviour
{
    Queue<Robot> robotQueue = new Queue<Robot>();
    [SerializeField] RobotGenerator robotGenerator;

    enum GameState { revealRobot, revealPart, repairRobot, revealResults, buyingCards, waiting };
    GameState currentGameState;

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
                ShowNextRobot();
                break;

            case GameState.revealPart:

                break;

            case GameState.repairRobot:

                break;

            case GameState.revealResults:

                break;

            case GameState.buyingCards:

                break;

            default:

                break;
        }
    }

    /// <summary>
    /// Called by RobotGenerator to add new robots to queue
    /// </summary>
    /// <param name="robotList"></param>
    public void AddRobots(List<Robot> robotList)
    {
        foreach (Robot robot in robotList)
        {
            robotQueue.Enqueue(robot);
        }
    }

    /// <summary>
    /// Called to reveal the next robot
    /// </summary>
    private void ShowNextRobot()
    {
        if (robotQueue.Count != 0)
        {
            Robot currentRobot = robotQueue.Dequeue();
        }

        // show dialogue + part
    }
}
