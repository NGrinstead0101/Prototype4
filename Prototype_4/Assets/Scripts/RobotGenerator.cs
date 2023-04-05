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

    public void GenerateRobots()
    {
        generatedRobots.Clear();

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

        while (generatedRobots.Count < targetRobotCount)
        {
            randCorp = Random.Range(0, 3);
            ++corpTallies[randCorp];
            generatedRobots.Insert(GetRandIndex(), GenerationHelper(randCorp));
        }

        gameStateTracker.AddRobots(generatedRobots);
    }

    private Robot GenerationHelper(int suit)
    {
        //Part newPart = partGenerator.GeneratePart();
        Sprite robotSprite = robotSpriteList[Random.Range(0, robotSpriteList.Count)];
        bool hasSecurity = Random.Range(0, 10) == 0;
        string dialogue = dialogueList[Random.Range(0, dialogueList.Count)];

        return new Robot(suit, /*newPart, */robotSprite, hasSecurity, dialogue);
    }

    private int GetRandIndex()
    {
        return Random.Range(0, generatedRobots.Count);
    }
}
