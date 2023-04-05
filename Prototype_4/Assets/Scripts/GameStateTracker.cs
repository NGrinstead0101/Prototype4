using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTracker : MonoBehaviour
{
    Queue<Robot> robotQueue = new Queue<Robot>();

    public void AddRobots(List<Robot> robotList)
    {
        foreach (Robot robot in robotList)
        {
            robotQueue.Enqueue(robot);
            Debug.Log("Corp: " + robot.Corp + "  Has Security: " + robot.HasSecurity + "  Dialogue: " + robot.Dialogue);
        }
    }

    private void ShowNextRobot()
    {
        Robot currentRobot = robotQueue.Dequeue();

        // show dialogue + part
    }
}
