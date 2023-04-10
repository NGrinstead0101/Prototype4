using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGenerator : MonoBehaviour
{
    [SerializeField] GameStateTracker gameStateTracker;

    [SerializeField] List<Sprite> robotSpriteList;
    [SerializeField] List<string> dialogueList;
    //[SerializeField] PartGenerator partGenerator;

    [SerializeField] int corpCountMin;
    [SerializeField] int corpCountMax;
    [SerializeField] int targetRobotCount;

    int[] corpTallies = new int[] { 0, 0, 0 };

    List<Robot> generatedRobots = new List<Robot>();

    /// <summary>
    /// Prevents infinite loop and ensures enough robots can be generated
    /// </summary>
    private void Awake()
    {
        while (corpCountMax * 3 < targetRobotCount)
        {
            corpCountMax++;
        }
    }

    /// <summary>
    /// Generates a number of robots before gicing all of them to GameStateManager
    /// </summary>
    public void GenerateRobots()
    {
        generatedRobots.Clear();

        // Creating the minimum number for each corporation
        for (int i = 0; i < 3; ++i)
        {
            corpTallies[i] = 0;

            for (int j = 0; j < corpCountMin; ++j)
            {
                ++corpTallies[i];
                generatedRobots.Insert(GetRandIndex(), GenerationHelper(i));
            }
        }

        int randCorp;

        // Generating the rest of the robots
        while (generatedRobots.Count < targetRobotCount)
        {
            randCorp = Random.Range(0, 3);

            if (corpTallies[randCorp] < corpCountMax)
            {
                ++corpTallies[randCorp];
                generatedRobots.Insert(GetRandIndex(), GenerationHelper(randCorp));
            }
        }

        // make check for displaying PA announcements?

        gameStateTracker.AddRobots(generatedRobots);
    }

    /// <summary>
    /// Creates a robot once the suit has been determined
    /// </summary>
    /// <param name="suit">The chosen corporation</param>
    /// <returns>A completed Robot</returns>
    private Robot GenerationHelper(int suit)
    {
        //Part newPart = GeneratePart();
        Sprite robotSprite = robotSpriteList[Random.Range(0, robotSpriteList.Count)];
        bool hasSecurity = Random.Range(0, 10) == 0;
        string dialogue = dialogueList[Random.Range(0, dialogueList.Count)];

        return new Robot(suit, /*newPart, */robotSprite, hasSecurity, dialogue);
    }

    /// <summary>
    /// Finds a random spot in generatedRobots list
    /// </summary>
    /// <returns></returns>
    private int GetRandIndex()
    {
        return Random.Range(0, generatedRobots.Count);
    }
}
