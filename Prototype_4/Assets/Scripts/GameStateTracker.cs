using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTracker : MonoBehaviour
{
    Queue<Robot> robotQueue = new Queue<Robot>();

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
        Robot currentRobot = robotQueue.Dequeue();

        // show dialogue + part
    }
}
